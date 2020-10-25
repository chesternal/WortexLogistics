using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WortexLogistics.Models;

namespace WortexLogistics.Pages.TruckCargos
{
    public class CreateModel : PageModel
    {
        private readonly Data.wortexlogisticsContext _context;

        public CreateModel(WortexLogistics.Data.wortexlogisticsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TruckCargo TruckCargo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TruckCargo.Add(TruckCargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
