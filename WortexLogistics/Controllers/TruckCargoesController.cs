using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WortexLogistics.Data;
using WortexLogistics.Models;

namespace WortexLogistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckCargoesController : ControllerBase
    {
        private readonly wortexlogisticsContext _context;
        
        public TruckCargoesController(wortexlogisticsContext context)
        {
            _context = context;
        }

        // GET: api/TruckCargoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckCargo>>> GetTruckCargo()
        {
            return await _context.TruckCargo.ToListAsync();
        }

        // GET: api/TruckCargoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TruckCargo>> GetTruckCargo(int id)
        {
            var truckCargo = await _context.TruckCargo.FindAsync(id);

            if (truckCargo == null)
            {
                return NotFound();
            }

            return truckCargo;
        }

        // PUT: api/TruckCargoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruckCargo(int id, TruckCargo truckCargo)
        {
            if (id != truckCargo.Id)
            {
                return BadRequest();
            }

            _context.Entry(truckCargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckCargoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TruckCargoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TruckCargo>> PostTruckCargo(TruckCargo truckCargo)
        {
            _context.TruckCargo.Add(truckCargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTruckCargo", new { id = truckCargo.Id }, truckCargo);
        }

        // DELETE: api/TruckCargoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TruckCargo>> DeleteTruckCargo(int id)
        {
            var truckCargo = await _context.TruckCargo.FindAsync(id);
            if (truckCargo == null)
            {
                return NotFound();
            }

            _context.TruckCargo.Remove(truckCargo);
            await _context.SaveChangesAsync();

            return truckCargo;
        }

        private bool TruckCargoExists(int id)
        {
            return _context.TruckCargo.Any(e => e.Id == id);
        }
    }
}
