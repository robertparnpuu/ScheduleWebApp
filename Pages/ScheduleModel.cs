using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
        public ShiftAssignmentView shiftAssignment {  get; set; }

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
            shiftAssignment = new ShiftAssignmentView();
            var obj = ssRepo.GetEntity(ssId);
            ObjToShiftAssignmentView(obj);

            VMToSession();
        }

        public async Task<IActionResult> OnPostSelectDateAsync()
        {
            //View topib scheduleviewi, ning kasutame VMToSession et scheduleViewist teha edasi antav Json sessionis
            //Hetkel ei leidnud moodust sessionit ise muuta, ehk topin olemasolevad viewi ja siis kirjutan sessioni yle
            
            ObjToShiftAssignmentView(SessionHelper.GetObjectFromJson<ShiftAssignmentView>(HttpContext.Session, "shiftAssignment"));
            shiftAssignment.startTime = CombineDateAndTime(shiftAssignment.dateChoice, shiftAssignment.startTime);
            shiftAssignment.endTime = CombineDateAndTime(shiftAssignment.dateChoice, shiftAssignment.endTime);
            VMToSession();
            return RedirectToPage("ScheduleTEST", new {handler = "ScheduleTEST"});
        }

        public async Task OnGetScheduleTESTAsync()
        {
            shiftAssignment = SessionHelper.GetObjectFromJson<ShiftAssignmentView>(HttpContext.Session, "shiftAssignment");
        }

        internal DateTime CombineDateAndTime(DateTime date, DateTime time) => 
        new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        

        private void ObjToShiftAssignmentView(dynamic obj)
        {
            //veri bäd pls refactor
            shiftAssignment.locationId = obj.locationId;
            shiftAssignment.occupationId = obj.occupationId;

            shiftAssignment.locationName = obj.GetType() == typeof(ShiftAssignmentView)
            ? obj.locationName
            : obj.shiftLocation.name;

            shiftAssignment.occupationName = obj.GetType() == typeof(ShiftAssignmentView)
            ? obj.occupationName
            : obj.shiftOccupation.name;

            shiftAssignment.startTime = obj.startTime;
            shiftAssignment.endTime = obj.endTime;
        }

        private void VMToSession()
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "shiftAssignment", shiftAssignment);
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
