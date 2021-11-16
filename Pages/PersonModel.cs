using System;
using System.Linq;
using System.Threading.Tasks;
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

namespace PageModels
{
    public class PersonModel : BaseModel<Person, PersonView>
    {
        internal IPartyContactRepo partyContact;
        internal IContactRepo contact;
        internal IAddressRepo address;
        //TODO: Concurrency pls
        public PersonModel(IPersonRepo r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a, ApplicationDbContext context) : base(r, context)
        {
            partyContact = pc;
            contact = c;
            address = a;
        }

        protected internal override PersonView ToView(Person obj)
        {
            PersonView view = new PersonView();
            Copy.Members(obj, view);
            return view;
        }
        protected internal PersonView PartyContactToView(Person obj)
        {
            PersonView view = ToView(obj);
            PartyContact p = partyContact.GetEntity(obj.partyContactId);
            Contact c = contact.GetEntity(obj.contactId);
            Address a = address.GetEntity(obj.addressId);

            view = Copy.Members(p, view, "id");
            view = Copy.Members(c, view, "id");
            view = Copy.Members(a, view, "id");
            return view;
        }
        
        protected internal override Person ToEntity(PersonView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new PersonData());
            return new Person(data);
        }

        protected internal PartyContact ToEntityPartyContact(PersonView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new PartyContactData(), "id");
            data.id = item.partyContactId;
            return new PartyContact(data);
        }

        protected internal Contact ToEntityContact(PersonView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ContactData(), "id");
            data.id = item.contactId;
            return new Contact(data);
        }
        protected internal Address ToEntityAddress(PersonView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new AddressData(), "id");
            data.id = item.addressId;
            return new Address(data);
        }

        //public SelectList PartyContacts
        //{
        //    get
        //    {
        //        var list = new GetRepo().Instance<IPartyContactRepo>().GetById();
        //        return new SelectList(list, "id", "id", item?.partyContactId);
        //    }
        //}

        public override async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            return await contact.UpdateAsync(ToEntityContact(item)) &&
                   await address.UpdateAsync(ToEntityAddress(item)) &&
                   await partyContact.UpdateAsync(ToEntityPartyContact(item)) &&
                   await repo.UpdateAsync(ToEntity(item)) 
            ? IndexPage() : Page();
        }

        public override async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            item.partyContactId = Guid.NewGuid().ToString();
            item.contactId = Guid.NewGuid().ToString();
            item.addressId = Guid.NewGuid().ToString();
            item.partyId = item.id;

            return await contact.AddAsync(ToEntityContact(item)) && 
                   await address.AddAsync(ToEntityAddress(item)) &&
                   await partyContact.AddAsync(ToEntityPartyContact(item)) &&
                   await repo.AddAsync(ToEntity(item)) ? 
            IndexPage() : Page();
        }
    }
}
