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
        //TODO: Concurrency pls
        public LocationModel(ILocationRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override LocationView ToView(Location obj)
        {
            LocationView view = new LocationView();
            Copy.Members(obj, view);
            //view.fullAddress = obj.locationContact.contactAddress?.fullAddress;
            view.fullContact = obj.locationContact?.fullContact;
            return view;
        }

        protected internal override Location ToEntity(LocationView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new LocationData());
            return new Location(data);
        }

        public SelectList Contacts
        {
            get
            {
                var list = new GetRepo().Instance<IContactRepo>().GetById();
                return new SelectList(list, "id", "fullContact", item?.contactId);
            }
        }
    }
}
