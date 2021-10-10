using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Core;
using Data;
using Domain;
using Domain.Repos;
using Facade;
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

        [BindProperty]
        public OccupationView item { get; set; }

        public IList<OccupationView> items { get; set; }

        public async Task OnGetIndexAsync() => items = (await repo.GetEntityListAsync()).Select(ToView).ToList();

        protected internal OccupationView ToView(Occupation obj)
        {
            OccupationView view = new OccupationView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal Occupation ToEntity(OccupationView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new OccupationData());
            return new Occupation(data);
        }

        public IActionResult OnGetCreate()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            
            return await repo.AddAsync(ToEntity(item)) ? IndexPage() : Page();
        }

        internal IActionResult IndexPage() => RedirectToPage("./Index", new { handler = "Index" });

        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //OccupationData = await _context.Occupations.FirstOrDefaultAsync(m => m.id == id);

            //if (OccupationData == null)
            //{
            //    return NotFound();
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //OccupationData = await _context.Occupations.FindAsync(id);

            //if (OccupationData != null)
            //{
            //    _context.Occupations.Remove(OccupationData);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            if (id == null) return null;

            item = ToView(await repo.GetEntityAsync(id));

            if (item == null) return null;
            return Page();
        }

        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //OccupationData = await _context.Occupations.FirstOrDefaultAsync(m => m.id == id);

            //if (OccupationData == null)
            //{
            //    return NotFound();
            //}
            return Page();
        }
    
        public async Task<IActionResult> OnPostEditAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(OccupationData).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OccupationDataExists(OccupationData.id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private bool OccupationDataExists(string id)
        {
            return _context.Occupations.Any(e => e.id == id);
        }
    }
}
