﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public DetailsModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public DepartmentData DepartmentData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepartmentData = await _context.Departments.FirstOrDefaultAsync(m => m.id == id);

            if (DepartmentData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}