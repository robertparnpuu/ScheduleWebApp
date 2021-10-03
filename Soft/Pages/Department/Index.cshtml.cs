using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Soft.Data;

namespace Soft.Pages.Department
{
    public class IndexModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public IndexModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DepartmentData> DepartmentData { get;set; }

        public async Task OnGetAsync()
        {
            DepartmentData = await _context.Departments.ToListAsync();
        }
    }
}
