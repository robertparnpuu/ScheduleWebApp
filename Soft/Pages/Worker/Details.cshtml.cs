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
    public class DetailsModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public DetailsModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
