using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PageModels.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PageModels
{
    public class ShiftAssignmentModel : ViewedModel<ShiftAssignment, ShiftAssignmentView>
    {
        public ShiftAssignmentModel(IShiftAssignmentRepo r, ApplicationDbContext context) : base(r, context)
        {
        }
        public override string PageTitle => "ShiftAssignment";

        public int CurrentWeekOffset = 0;

        public async Task<IActionResult> OnGetIndexAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, int weekOffset = 0)
        {
            //repo = (IShiftAssignmentRepo)repo;
            int dayFromWeekStart = (int)DateTime.Now.DayOfWeek;
            if (dayFromWeekStart == 0) dayFromWeekStart = 6;
            else dayFromWeekStart -= 1;
            DateTime start = DateTime.Today.AddDays(-dayFromWeekStart + weekOffset * 7);
            DateTime end = DateTime.Today.AddDays(1 + weekOffset * 7);
            PageIndex = pageIndex;
            SearchString = searchString;
            CurrentFilter = currentFilter;
            SortOrder = sortOrder;
            CurrentWeekOffset = weekOffset;

            items = (await repo.GetEntityListAsync(start, end)).Select(ToView).ToList();
            
            return Page();
        }

        protected internal override ShiftAssignmentView ToView(ShiftAssignment obj)
        {
            ShiftAssignmentView view = new ShiftAssignmentView();
            Copy.Members(obj, view);
            view.locationName = obj?.shiftAssignmentLocation?.name;
            view.personName = obj?.shiftAssignmentContract?.contractPerson.fullName;

            return view;
        }
        //TODO 12. siia vaja filtrid
        protected internal override ShiftAssignment ToEntity(ShiftAssignmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ShiftAssignmentData());
            return new ShiftAssignment(data);
        }

        public SelectList Contracts
        {
            get
            {
                var list = new GetRepo().Instance<IContractRepo>().GetById();
                return new SelectList(list, "id", "personName", item?.contractId);
            }
        }
        public SelectList Locations
        {
            get
            {
                var list = new GetRepo().Instance<ILocationRepo>().GetById();
                return new SelectList(list, "id", "name", item?.locationId);
            }
        }
    }
}