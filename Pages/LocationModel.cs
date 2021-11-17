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
    public class LocationModel : WithContactModel<Location, LocationView>
    {

        private ILocationRepo mockRepo;

        public LocationModel(ILocationRepo r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a,
        ApplicationDbContext context) : base(r, pc, c, a, context) { }

        protected internal override LocationView ToView(Location obj)
        {
            LocationView view = new LocationView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal override Location ToEntity(LocationView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new LocationData());
            return new Location(data);
        }
    }
}
