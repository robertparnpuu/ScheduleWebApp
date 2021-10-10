using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Infra;

namespace Soft.Pages.Requirement
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RequirementData> requirementData { get;set; }

        public async Task OnGetAsync()
        {
            requirementData = await _context.Requirements.ToListAsync();
        }
    }
}
