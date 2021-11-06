using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PageModels.Common;

namespace PageModels
{
    public class ScheduleModel : PageModel
    {
        [BindProperty]
        public List<StandardShiftView> standardShifts { get; set; }

        //Causes ModelState invalid
        //[BindProperty]
        //public ShiftAssignmentView shiftAssignment { get; set; }

        [BindProperty]
        public ScheduleView scheduleView {  get; set; }

        protected readonly IRepo<StandardShift> ssRepo;
        protected readonly ApplicationDbContext _context;
        
        public ScheduleModel(IStandardShiftRepo sShiftRepo, ApplicationDbContext context)
        {
            ssRepo = sShiftRepo;
            _context = context;
        }
        public async Task OnGetIndexAsync()
        {
            standardShifts = (await ssRepo.GetEntityListAsync()).Select(SSToView).ToList();
        }

        public async Task OnGetSelectDateAsync(string ssId)
        {
            scheduleView = new ScheduleView();
            var obj = ssRepo.GetEntity(ssId);
            scheduleView.locationId = obj.locationId;

            VMToSession();
        }

        public async Task<IActionResult> OnPostSelectDateAsync()
        {
            //View topib scheduleviewi, ning kasutame VMToSession et scheduleViewist teha edasi antav Json sessionis
            //Hetkel ei leidnud moodust sessionit ise muuta, ehk topin olemasolevad viewi ja siis kirjutan sessioni yle
            scheduleView.locationId = SessionHelper.GetObjectFromJson<ScheduleView>(HttpContext.Session, "scheduleView")
            .locationId;
            VMToSession();
            return RedirectToPage("ScheduleTEST", new {handler = "ScheduleTEST"});
        }

        private void VMToSession()
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "scheduleView", scheduleView);
        }

        public async Task OnGetScheduleTESTAsync()
        {
            scheduleView = SessionHelper.GetObjectFromJson<ScheduleView>(HttpContext.Session, "scheduleView");
        }

        protected internal StandardShiftView SSToView(StandardShift obj)
        {
            StandardShiftView view = new StandardShiftView();
            Copy.Members(obj, view);
            view.locationName = obj?.shiftLocation?.name;
            view.occupationName = obj?.shiftOccupation?.name;
            return view;
        }
    }
}
