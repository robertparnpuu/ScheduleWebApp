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
    public class LocationModel : BaseModel<Location, LocationView>
    {
        public LocationModel(ILocationRepo r, ApplicationDbContext context) : base(r, context) { }

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

        public SelectList PartyContacts
        {
            get
            {
                var list = new GetRepo().Instance<IPartyContactRepo>().GetById();
                return new SelectList(list, "id", "id", item?.partyContactId);
            }
        }
    }
}
