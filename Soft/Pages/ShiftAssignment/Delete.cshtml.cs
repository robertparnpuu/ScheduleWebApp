using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Soft.Data;

namespace Soft.Pages.ShiftAssignment
{
    public class DeleteModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public DeleteModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShiftAssignmentData ShiftAssignmentData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShiftAssignmentData = await _context.ShiftAssignments.FirstOrDefaultAsync(m => m.id == id);

            if (ShiftAssignmentData == null)
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

            ShiftAssignmentData = await _context.ShiftAssignments.FindAsync(id);

            if (ShiftAssignmentData != null)
            {
                _context.ShiftAssignments.Remove(ShiftAssignmentData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
