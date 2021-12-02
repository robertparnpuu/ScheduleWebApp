using System;
using System.Threading.Tasks;
using Aids;
using Core;
using Data;
using Domain;
using Domain.Repos;
using Facade.Common;
using Infra;
using Microsoft.AspNetCore.Mvc;

namespace PageModels.Common
{
    public abstract class WithContactModel<TEntity, TView> : ViewModel<TEntity, TView>
    where TEntity : class, IBaseEntity, new() 
    where TView : WithContactView, new()
    {
    protected IPartyContactRepo partyContact;
    protected IContactRepo contact;
    protected IAddressRepo address;

        protected WithContactModel(IRepo<TEntity> r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a,
        ApplicationDbContext context) : base(r, context)
        {
            partyContact = pc;
            contact = c;
            address = a;
        }

        protected internal PartyContact ToEntityPartyContact(TView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new PartyContactData(), "id");
            data.id = item.partyContactId;
            return new PartyContact(data);
        }

        protected internal Contact ToEntityContact(TView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ContactData(), "id");
            data.id = item.contactId;
            return new Contact(data);
        }

        protected internal Address ToEntityAddress(TView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new AddressData(), "id");
            data.id = item.addressId;
            return new Address(data);
        }

        protected internal override async Task<bool> GetItemAsync(string id)
        {
            if (id == null) return false;
            TEntity p = (await repo.GetEntityAsync(id));
            item = ToView(p);
            PartyContact pc = await partyContact.GetEntityAsync(item.partyContactId);
            Contact c = await contact.GetEntityAsync(item.contactId);
            Address a = await address.GetEntityAsync(item.addressId);

            item = Copy.Members(pc, item, "id");
            item = Copy.Members(c, item, "id");
            item = Copy.Members(a, item, "id");
            return item != null && item.id != "Unspecified";
        }

        public override async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            return await repo.UpdateAsync(ToEntity(item)) &&
                   await address.UpdateAsync(ToEntityAddress(item)) &&
                   await partyContact.UpdateAsync(ToEntityPartyContact(item)) &&
                   await contact.UpdateAsync(ToEntityContact(item)) ? IndexPage() : Page();
        }

        public override async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            item.partyContactId = Guid.NewGuid().ToString();
            item.contactId = Guid.NewGuid().ToString();
            item.addressId = Guid.NewGuid().ToString();
            item.partyId = item.id;

            return await repo.AddAsync(ToEntity(item)) && 
                   await address.AddAsync(ToEntityAddress(item)) && 
                   await partyContact.AddAsync(ToEntityPartyContact(item)) && 
                   await contact.AddAsync(ToEntityContact(item)) ? IndexPage() : Page();
        }
    }
}
