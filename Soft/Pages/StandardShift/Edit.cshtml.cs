using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Soft.Data;

namespace Soft.Pages.StandardShift
{
    public class EditModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public EditModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StandardShiftData StandardShiftData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StandardShiftData = await _context.StandardShifts.FirstOrDefaultAsync(m => m.id == id);

            if (StandardShiftData == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StandardShiftData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardShiftDataExists(StandardShiftData.id))
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

        private bool StandardShiftDataExists(string id)
        {
            return _context.StandardShifts.Any(e => e.id == id);
        }
    }
}
