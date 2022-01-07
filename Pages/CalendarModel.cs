using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
            var currentuser = User;
            var currentUserId = currentuser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
            if (user != null)
            {
                var personId = user.PersonId;
                repo.startTime = DateTime.MinValue;
                repo.endTime = DateTime.MaxValue;
                items = (await repo.GetEntityListAsync()).Select(ToCalendarView).Where(x => x.personId == personId).ToList();
            }
            itemsAsJson = JsonConvert.SerializeObject(items);
            return Page();
        }

        protected internal CalendarView ToCalendarView(ShiftAssignment obj)
        {
            var view = new CalendarView
            {personId = obj.shiftAssignmentContract?.personId,
            id = obj.id,
            title = $"{obj.shiftAssignmentContract?.contractOccupation.name}. {obj.shiftAssignmentLocation?.name}",
            start = obj.startTime,
            end = obj.endTime};
            return view;
        }
    }
}
