﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using Soft.Data;

namespace Soft.Pages.Requirement
{
    public class CreateModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public CreateModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RequirementData RequirementData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Requirements.Add(RequirementData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
