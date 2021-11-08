﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModels
{
    public class ScheduleModel : PageModel
    {
        [BindProperty]
        public List<StandardShiftView> standardShifts { get; set; }
        [BindProperty]
        public List<PersonView> people { get; set; }

        [BindProperty]
        public ShiftAssignmentView shiftAssignment {  get; set; }

        protected readonly IRepo<StandardShift> ssRepo;
        protected readonly IRepo<Person> pRepo;
        protected readonly ApplicationDbContext _context;
        
        public ScheduleModel(IStandardShiftRepo sShiftRepo, IPersonRepo personRepo, ApplicationDbContext context)
        {
            ssRepo = sShiftRepo;
            pRepo = personRepo;
            _context = context;
        }
        public async Task OnGetIndexAsync() => standardShifts = (await ssRepo.GetEntityListAsync()).Select(SSToView).ToList();
        

        public async Task OnGetSelectDateAsync(string ssId)
        {
            shiftAssignment = new ShiftAssignmentView();
            shiftAssignment.dateChoice = DateTime.Now;
            StandardShiftView ssView = SSToView(await ssRepo.GetEntityAsync(ssId));
            Copy.Members(ssView, shiftAssignment, "dateChoice");

            VMToSession();
        }

        public async Task<IActionResult> OnPostSelectDateAsync()
        {
            //View topib scheduleviewi, ning kasutame VMToSession et scheduleViewist teha edasi antav Json sessionis
            //Hetkel ei leidnud moodust sessionit ise muuta, ehk topin olemasolevad viewi ja siis kirjutan sessioni yle
            
            Copy.Members(GetSessionObject("shiftAssignment"), shiftAssignment, "dateChoice");
            shiftAssignment.startTime = CombineDateAndTime(shiftAssignment.dateChoice, shiftAssignment.startTime);
            shiftAssignment.endTime = CombineDateAndTime(shiftAssignment.dateChoice, shiftAssignment.endTime);
            VMToSession();
            return RedirectToPage("ScheduleTEST", new {handler = "ScheduleTEST"});
        }

        public async Task OnGetScheduleTESTAsync()
        {
            shiftAssignment = GetSessionObject("shiftAssignment");
            people = (await pRepo.GetEntityListAsync()).Select(PersonToView).ToList();
        }

        public async Task OnGetConfirmAssignmentAsync(string pId)
        {
            shiftAssignment = new ShiftAssignmentView();
            Copy.Members(GetSessionObject("shiftAssignment"), shiftAssignment, "dateChoice");
            PersonView person = PersonToView(await pRepo.GetEntityAsync(pId));
            shiftAssignment.personId = person.id;
            shiftAssignment.personName = person.fullName;

            VMToSession();
        }

        protected internal void VMToSession() =>
        HttpContext.Session.SetObjectAsJson("shiftAssignment", shiftAssignment);

        protected internal ShiftAssignmentView GetSessionObject(string key) =>
        HttpContext.Session.GetObjectFromJson<ShiftAssignmentView>(key);

        protected internal DateTime CombineDateAndTime(DateTime date, DateTime time) => 
        new(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

        protected internal PersonView PersonToView(Person obj) => Copy.Members(obj, new PersonView());

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
