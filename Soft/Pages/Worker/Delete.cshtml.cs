using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Infra;

namespace Soft.Pages.Worker
{
    public class DeleteModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public DeleteModel(Infra.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkerData = await _context.Workers.FindAsync(id);

            if (WorkerData != null)
            {
                _context.Workers.Remove(WorkerData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
