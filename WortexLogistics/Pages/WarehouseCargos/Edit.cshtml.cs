﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WortexLogistics.Models;

namespace WortexLogistics.Pages.WarehouseCargos
{
    public class EditModel : PageModel
    {
        private readonly WortexLogistics.Models.wortexlogisticsContext _context;

        public EditModel(WortexLogistics.Models.wortexlogisticsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WarehouseCargo WarehouseCargo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WarehouseCargo = await _context.WarehouseCargo.FirstOrDefaultAsync(m => m.Id == id);

            if (WarehouseCargo == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WarehouseCargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseCargoExists(WarehouseCargo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WarehouseCargoExists(int id)
        {
            return _context.WarehouseCargo.Any(e => e.Id == id);
        }
    }
}