using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WortexLogistics.Models;

namespace WortexLogistics.Pages.TruckCargos
{
    public class DetailsModel : PageModel
    {
        private readonly WortexLogistics.Models.wortexlogisticsContext _context;

        public DetailsModel(WortexLogistics.Models.wortexlogisticsContext context)
        {
            _context = context;
        }

        public TruckCargo TruckCargo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TruckCargo = await _context.TruckCargo.FirstOrDefaultAsync(m => m.Id == id);

            if (TruckCargo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
