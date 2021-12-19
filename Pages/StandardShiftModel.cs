using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PageModels.Common;

namespace PageModels
{
    [Authorize(Roles = "Admin,Scheduler")]
    public class StandardShiftModel : ViewModel<StandardShift, StandardShiftView>
    {
        public StandardShiftModel(IStandardShiftRepo r, ApplicationDbContext context) : base(r, context)
        {
        }
        public override string PageTitle => "StandardShift";
        protected internal override StandardShiftView ToView(StandardShift obj)
        {
            StandardShiftView view = new StandardShiftView();
            Copy.Members(obj, view);
            view.locationName = obj?.shiftLocation?.name;
            view.occupationName = obj?.shiftOccupation?.name;
            return view;
        }
        //TODO 13. siia vaja filtrid
        protected internal override StandardShift ToEntity(StandardShiftView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new StandardShiftData());
            return new StandardShift(data);
        }

        public SelectList Occupations
        {
            get
            {
                var list = new GetRepo().Instance<IOccupationRepo>().GetById();
                return new SelectList(list, "id", "name", item?.occupationId);
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