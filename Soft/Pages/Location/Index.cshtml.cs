using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Infra;

namespace Soft.Pages.Location
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LocationData> locationData { get;set; }

        public async Task OnGetAsync()
        {
            locationData = await _context.Locations.ToListAsync();
        }
    }
}
