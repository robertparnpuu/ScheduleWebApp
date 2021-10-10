﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Soft.Data;

namespace Soft.Pages.Address
{
    public class DetailsModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public DetailsModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AddressData AddressData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressData = await _context.Addresses.FirstOrDefaultAsync(m => m.id == id);

            if (AddressData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
