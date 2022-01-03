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
    public class ContactModel : ViewModel<Contact, ContactView>
    {
        public ContactModel(IContactRepo r, ApplicationDbContext context) : base(r, context)
        {
        }
        public override string PageTitle => "Contact";
        protected internal override ContactView ToView(Contact obj)
        {
            ContactView view = new ContactView();
            Copy.Members(obj, view);

            return view;
        }

        protected internal override Contact ToEntity(ContactView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ContactData());
            return new Contact(data);
        }

    }
}
