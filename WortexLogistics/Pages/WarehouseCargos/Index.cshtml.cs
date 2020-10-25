using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WortexLogistics.Models;

namespace WortexLogistics.Pages.WarehouseCargos
{
    public class IndexModel : PageModel
    {
        private readonly WortexLogistics.Data.wortexlogisticsContext _context;

        public IndexModel(WortexLogistics.Data.wortexlogisticsContext context)
        {
            _context = context;
        }

        public IList<WarehouseCargo> WarehouseCargo { get;set; }
        public int TotalCargo { get;set; }
        public string CargoText { get; set; }
        public string Errors { get; set; }

        public async Task OnGetAsync()
        {
            TotalCargo = 0;
            WarehouseCargo = await _context.WarehouseCargo.ToListAsync();
            foreach (var cargo in WarehouseCargo)
            {
                if (cargo == null)
                {
                    Errors = "ERROR: No cargo!";
                }
                else
                {
                    TotalCargo = TotalCargo + cargo.WcargoCount;
                }
            }
            if (TotalCargo == 0)
            {
                CargoText = "No cargo in the warehouse!";
            }
            else
            {
                CargoText = TotalCargo.ToString() + " cargo in the warehouse!";
            }
        }
    }
}
