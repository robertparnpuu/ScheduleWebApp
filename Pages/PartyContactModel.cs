using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using PageModels.Common;
using System.Web.Mvc;

namespace PageModels
{
    public class PartyContactModel : BaseModel<PartyContact, PartyContactView>
    {
        public PartyContactModel(IPartyContactRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override PartyContactView ToView(PartyContact obj)
        {
            PartyContactView view = new PartyContactView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal override PartyContact ToEntity(PartyContactView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new PartyContactData());
            return new PartyContact(data);
        }
        public SelectList Contacts
        {
            get
            {
                var list = new GetRepo().Instance<IContactRepo>().GetById();
                return new SelectList(list, "id", "id", item?.contactId);
            }
        }
        public SelectList Addresses
        {
            get
            {
                var list = new GetRepo().Instance<IAddressRepo>().GetById();
                return new SelectList(list, "id", "id", item?.addressId);
            }
        }
    }
}

