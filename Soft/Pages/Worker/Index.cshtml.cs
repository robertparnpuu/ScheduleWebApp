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
    public class IndexModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public IndexModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WorkerData> WorkerData { get;set; }

        public async Task OnGetAsync()
        {
            WorkerData = await _context.Workers.ToListAsync();
        }
    }
}
