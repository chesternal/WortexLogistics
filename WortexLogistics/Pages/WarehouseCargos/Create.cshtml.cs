using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WortexLogistics.Models;

namespace WortexLogistics.Pages.WarehouseCargos
{
    public class CreateModel : PageModel
    {
        private readonly WortexLogistics.Data.wortexlogisticsContext _context;

        public CreateModel(WortexLogistics.Data.wortexlogisticsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WarehouseCargo WarehouseCargo { get; set; }
        public string ErrorName { get; set; }
        public string ErrorCount { get; set; }
        public string ErrorWeight { get; set; }
        public string ErrorOrigin { get; set; }
        public string ErrorDestination { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
            int errors = 0;
                if (WarehouseCargo.WcargoName == "Wrong" || WarehouseCargo.WcargoName == "")
                {
                    ErrorName = "Error in Name!";
                    errors = 1;
                }
                else if (WarehouseCargo.WcargoCount > 100 || WarehouseCargo.WcargoCount < 0)
                {
                    ErrorCount = "Error in Count!";
                    errors = 1;
                 }
                else if (WarehouseCargo.WcargoWeight <= 0 || WarehouseCargo.WcargoWeight > 50)
                {
                    ErrorWeight = "Error in Weight!";
                    errors = 1;
                 }
                else if (WarehouseCargo.WcargoOrigin == "Heaven" || WarehouseCargo.WcargoOrigin == "")
                {
                    ErrorOrigin = "Error in Origin!";
                    errors = 1;
                 }
                else if (WarehouseCargo.WcargoDestination == "Hell" || WarehouseCargo.WcargoDestination == "")
                {
                    ErrorDestination = "Error in Destination!";
                errors = 1;
            }
                
           // }
            if(errors == 1)
            {
                return Page();
            }
            else if(errors == 0)
            {
                _context.WarehouseCargo.Add(WarehouseCargo);
                await _context.SaveChangesAsync();

                
            }
            return RedirectToPage("./Index");
        }
    }
}
