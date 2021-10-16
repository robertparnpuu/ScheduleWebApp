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
    public class ContactModel : BaseModel<Contact, ContactView>
    {
        //TODO: Concurrency pls
        public ContactModel(IContactRepo r, ApplicationDbContext context) : base(r, context)
        {
        }

        protected internal override ContactView ToView(Contact obj)
        {
            ContactView view = new ContactView();
            Copy.Members(obj, view);
            view.fullAddress = obj.contactAddress?.fullAddress;
            return view;
        }

        protected internal override Contact ToEntity(ContactView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ContactData());
            return new Contact(data);
        }

        public SelectList Addresses
        { 
            get
            {
                var list = new GetRepo().Instance<IAddressRepo>().GetById();
                return new SelectList(list, "id", "fullAddress", item?.addressId);
            }
        }
    }
}
