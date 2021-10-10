﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Infra;

namespace Soft.Pages.ShiftAssignment
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ShiftAssignmentData ShiftAssignmentData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShiftAssignmentData = await _context.ShiftAssignments.FirstOrDefaultAsync(m => m.id == id);

            if (ShiftAssignmentData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
