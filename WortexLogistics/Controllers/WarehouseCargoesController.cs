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
    public class WarehouseCargoesController : ControllerBase
    {
        private readonly wortexlogisticsContext _context;

        public WarehouseCargoesController(wortexlogisticsContext context)
        {
            _context = context;
        }

        // GET: api/WarehouseCargoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseCargo>>> GetWarehouseCargo()
        {
            return await _context.WarehouseCargo.ToListAsync();
        }

        // GET: api/WarehouseCargoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseCargo>> GetWarehouseCargo(int id)
        {
            var warehouseCargo = await _context.WarehouseCargo.FindAsync(id);

            if (warehouseCargo == null)
            {
                return NotFound();
            }

            return warehouseCargo;
        }

        // PUT: api/WarehouseCargoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouseCargo(int id, WarehouseCargo warehouseCargo)
        {
            if (id != warehouseCargo.Id)
            {
                return BadRequest();
            }

            _context.Entry(warehouseCargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseCargoExists(id))
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

        // POST: api/WarehouseCargoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WarehouseCargo>> PostWarehouseCargo(WarehouseCargo warehouseCargo)
        {
            _context.WarehouseCargo.Add(warehouseCargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarehouseCargo", new { id = warehouseCargo.Id }, warehouseCargo);
        }

        // DELETE: api/WarehouseCargoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WarehouseCargo>> DeleteWarehouseCargo(int id)
        {
            var warehouseCargo = await _context.WarehouseCargo.FindAsync(id);
            if (warehouseCargo == null)
            {
                return NotFound();
            }

            _context.WarehouseCargo.Remove(warehouseCargo);
            await _context.SaveChangesAsync();

            return warehouseCargo;
        }

        private bool WarehouseCargoExists(int id)
        {
            return _context.WarehouseCargo.Any(e => e.Id == id);
        }
    }
}
