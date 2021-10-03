using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Soft.Data;

namespace Soft.Pages.ShiftAssignment
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ShiftAssignmentData> shiftAssignmentData { get;set; }

        public async Task OnGetAsync()
        {
            shiftAssignmentData = await _context.ShiftAssignments.ToListAsync();
        }
    }
}
