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
    public class ShiftAssignmentModel : BaseModel<ShiftAssignment, ShiftAssignmentView>
    {
        //TODO: Concurrency pls
        public ShiftAssignmentModel(IShiftAssignmentRepo r, ApplicationDbContext context) : base(r, context)
        {
        }

        protected internal override ShiftAssignmentView ToView(ShiftAssignment obj)
        {
            ShiftAssignmentView view = new ShiftAssignmentView();
            Copy.Members(obj, view);
            view.locationName = obj.shiftAssignmentLocation?.name;
            view.personName = obj.shiftAssignmentPerson.fullName;

            return view;
        }

        protected internal override ShiftAssignment ToEntity(ShiftAssignmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ShiftAssignmentData());
            return new ShiftAssignment(data);
        }

        public SelectList Persons
        {
            get
            {
                var list = new GetRepo().Instance<IPersonRepo>().GetById();
                return new SelectList(list, "id", "fullName", item?.personId);
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