﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace PageModels
{
    [Authorize(Roles = "Admin, Viewer")]
    public class CalendarModel : PageModel
    {
        // Kasutame FullCalendar JS libraryt
        protected readonly IShiftAssignmentRepo repo;
        protected readonly ApplicationDbContext _context;

        public List<CalendarView> items;
        public string itemsAsJson;

        public CalendarModel(IShiftAssignmentRepo r, ApplicationDbContext context)
        {
            repo = r;
            _context = context;
            items = new List<CalendarView>();
        }

        public async Task<IActionResult> OnGetIndexAsync()
        {
            repo.startTime = DateTime.MinValue;
            repo.endTime = DateTime.MaxValue;
            items = (await repo.GetEntityListAsync()).Select(ToCalendarView).ToList();
            itemsAsJson = JsonConvert.SerializeObject(items);
            return Page();
        }

        // Õigem lahendus oleks API-ga
        // https://www.youtube.com/watch?v=39J0mSKM0QU tegi sellise lahendusega
        // Päris dokk https://fullcalendar.io/docs/events-json-feed
        //public async Task<JsonResult> OnGetEventsAsync()
        //{
        //    repo.startTime = DateTime.MinValue;
        //    repo.endTime = DateTime.MaxValue;
        //    items = (await repo.GetEntityListAsync()).Select(ToCalendarView).ToList();
        //    return new JsonResult(items);
        //}

        protected internal CalendarView ToCalendarView(ShiftAssignment obj)
        {
            CalendarView view = new CalendarView();
            view.id = obj.id;
            view.title = $"{obj.shiftAssignmentContract.contractOccupation.name}. {obj.shiftAssignmentLocation.name}";
            view.start = obj.startTime;
            view.end = obj.endTime;
            return view;
        }
    }
}