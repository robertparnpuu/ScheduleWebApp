using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc;
using PageModels.Common;

namespace PageModels
{
    public class ScheduleModel : BaseModel<ShiftAssignment, ShiftAssignmentView>
    {
        [BindProperty]
        public List<StandardShiftView> standardShifts { get; set; }
        [BindProperty]
        public List<PersonView> people { get; set; }
        
        protected readonly IRepo<StandardShift> ssRepo;
        protected readonly IRepo<Person> pRepo;
        
        public ScheduleModel(IShiftAssignmentRepo r, IStandardShiftRepo sShiftRepo, IPersonRepo personRepo, ApplicationDbContext context) : base(r, context)
        {
            ssRepo = sShiftRepo;
            pRepo = personRepo;
        }
        public async Task OnGetIndexAsync() => standardShifts = (await ssRepo.GetEntityListAsync()).Select(SSToView).ToList();
        
        public async Task OnGetSelectDateAsync(string ssId)
        {
            item = new ShiftAssignmentView();
            item.dateChoice = DateTime.Now;
            StandardShiftView ssView = SSToView(await ssRepo.GetEntityAsync(ssId));
            Copy.Members(ssView, item, "dateChoice", "id");

            VMToSession();
        }

        public async Task<IActionResult> OnPostSelectDateAsync()
        {
            //View topib scheduleviewi, ning kasutame VMToSession et scheduleViewist teha edasi antav Json sessionis
            //Hetkel ei leidnud moodust sessionit ise muuta, ehk topin olemasolevad viewi ja siis kirjutan sessioni yle
            
            Copy.Members(GetSessionObject("shiftAssignment"), item, "dateChoice");
            item.startTime = Combine.DateAndTime(item.dateChoice, item.startTime);
            item.endTime = Combine.DateAndTime(item.dateChoice, item.endTime);
            VMToSession();
            return RedirectToPage("ChooseWorker", new {handler = "ChooseWorker" });
        }

        public async Task OnGetChooseWorkerAsync()
        {
            item = GetSessionObject("shiftAssignment");
            people = (await pRepo.GetEntityListAsync()).Select(PersonToView).ToList();
        }

        public async Task OnGetConfirmAssignmentAsync(string pId)
        {
            item = new ShiftAssignmentView();
            Copy.Members(GetSessionObject("shiftAssignment"), item, "dateChoice");
            PersonView person = PersonToView(await pRepo.GetEntityAsync(pId));
            item.personId = person.id;
            item.personName = person.firstName+" "+person.lastName;

            VMToSession();
        }

        public async Task<IActionResult> OnPostConfirmAssignmentAsync()
        {
            item = GetSessionObject("shiftAssignment");
            ClearAndValidateItemModelState();
            if (!ModelState.IsValid) return Page();
            return await repo.AddAsync(ToEntity(item)) ? RedirectToPage("./StandardShifts", new { handler = "Index" }) : Page();
        }

        protected internal void ClearAndValidateItemModelState()
        {
            ModelState.Clear();
            TryValidateModel(item);
        }

        protected internal void VMToSession() =>
        HttpContext.Session.SetObjectAsJson("shiftAssignment", item);

        protected internal ShiftAssignmentView GetSessionObject(string key) =>
        HttpContext.Session.GetObjectFromJson<ShiftAssignmentView>(key);

        protected internal PersonView PersonToView(Person obj) => Copy.Members(obj, new PersonView());

        protected internal StandardShiftView SSToView(StandardShift obj)
        {
            StandardShiftView view = new StandardShiftView();
            Copy.Members(obj, view);
            view.locationName = obj?.shiftLocation?.name;
            view.occupationName = obj?.shiftOccupation?.name;
            return view;
        }

        protected internal override ShiftAssignmentView ToView(ShiftAssignment obj)
        {
            ShiftAssignmentView view = new ShiftAssignmentView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal override ShiftAssignment ToEntity(ShiftAssignmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ShiftAssignmentData());
            return new ShiftAssignment(data);
        }
    }
}
