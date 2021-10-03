using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Soft.Data;

namespace Soft.Pages.StandardShift
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StandardShiftData> standardShiftData { get;set; }

        public async Task OnGetAsync()
        {
            standardShiftData = await _context.StandardShifts.ToListAsync();
        }
    }
}
