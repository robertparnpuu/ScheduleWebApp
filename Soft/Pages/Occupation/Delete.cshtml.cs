using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Soft.Data;

namespace Soft.Pages.Occupation
{
    public class DeleteModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public DeleteModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OccupationData OccupationData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationData = await _context.Occupations.FirstOrDefaultAsync(m => m.id == id);

            if (OccupationData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationData = await _context.Occupations.FindAsync(id);

            if (OccupationData != null)
            {
                _context.Occupations.Remove(OccupationData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
