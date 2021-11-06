using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using PageModels.Common;

namespace PageModels
{
    public class RequirementModel: BaseModel<Requirement, RequirementView>
    {
        //TODO: Needs checkboxes for weekdays
        public RequirementModel(IRequirementRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override RequirementView ToView(Requirement obj)
        {
            RequirementView view = new RequirementView();
            Copy.Members(obj, view);
            view.locationName = obj?.requirementLocation?.name;
            view.occupationName = obj?.requirementOccupation?.name;
            view.weekDayName = obj?.requirementWeekDay?.name;

            return view;
        }

        protected internal override Requirement ToEntity(RequirementView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new RequirementData());
            return new Requirement(data);
        }

        public SelectList Locations
        {
            get
            {
                var list = new GetRepo().Instance<ILocationRepo>().GetById();
                return new SelectList(list, "id", "name", item?.locationId);
            }
        }
        public SelectList Occupations
        {
            get
            {
                var list = new GetRepo().Instance<IOccupationRepo>().GetById();
                return new SelectList(list, "id", "name", item?.occupationId);
            }
        }

        public SelectList WeekDays
        {
            get
            {
                var list = new GetRepo().Instance<IWeekDayRepo>().GetById();
                return new SelectList(list, "id", "name", item?.weekDayId);
            }
        }
    }
}
