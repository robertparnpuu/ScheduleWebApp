using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Authorization;
using PageModels.Common;

namespace PageModels
{
    [Authorize(Roles = "Admin,Manager")]
    public class LocationModel : WithContactModel<Location, LocationView>
    {
        
        public LocationModel(ILocationRepo r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a,
        ApplicationDbContext context) : base(r, pc, c, a, context) { }
        public override string PageTitle => "Location";
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
