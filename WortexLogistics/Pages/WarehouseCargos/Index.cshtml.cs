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
        private readonly WortexLogistics.Models.wortexlogisticsContext _context;

        public IndexModel(WortexLogistics.Models.wortexlogisticsContext context)
        {
            _context = context;
        }

        public IList<WarehouseCargo> WarehouseCargo { get;set; }

        public async Task OnGetAsync()
        {
            WarehouseCargo = await _context.WarehouseCargo.ToListAsync();
        }
    }
}
