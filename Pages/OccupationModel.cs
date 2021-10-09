using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Domain;
using Domain.Repos;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PageModels
{
    public class OccupationModel: PageModel, IBasePage
    {

        private readonly IOccupationRepo repo;
        private readonly ApplicationDbContext _context;

        public OccupationModel(IOccupationRepo r, ApplicationDbContext context)
        {
            repo = r;
            _context = context;
        }

        public IActionResult OnGetCreate()
        {
            return Page();
        }

        [BindProperty]
        public OccupationData OccupationData { get; set; }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Occupations.Add(OccupationData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationData = await _context.Occupations.FirstOrDefaultAsync(m => m.id == id);

            if (OccupationData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationData = await _context.Occupations.FindAsync(id);

            if (OccupationData != null)
            {
                _context.Occupations.Remove(OccupationData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationData = await _context.Occupations.FirstOrDefaultAsync(m => m.id == id);

            if (OccupationData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationData = await _context.Occupations.FirstOrDefaultAsync(m => m.id == id);

            if (OccupationData == null)
            {
                return NotFound();
            }
            return Page();
        }
    
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OccupationData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccupationDataExists(OccupationData.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OccupationDataExists(string id)
        {
            return _context.Occupations.Any(e => e.id == id);
        }

        public IList<Occupation> items { get; set; }

        public async Task OnGetIndexAsync()
        {
            items = await repo.GetEntityAsync();
        }


}
}
