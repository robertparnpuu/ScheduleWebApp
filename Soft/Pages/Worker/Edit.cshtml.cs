using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Infra;

namespace Soft.Pages.Worker
{
    public class EditModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public EditModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkerData WorkerData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkerData = await _context.Workers.FirstOrDefaultAsync(m => m.id == id);

            if (WorkerData == null)
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

            _context.Attach(WorkerData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerDataExists(WorkerData.id))
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

        private bool WorkerDataExists(string id)
        {
            return _context.Workers.Any(e => e.id == id);
        }
    }
}
