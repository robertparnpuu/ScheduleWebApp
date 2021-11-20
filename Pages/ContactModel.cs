using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using PageModels.Common;

namespace PageModels
{
    public class ContactModel : ViewedModel<Contact, ContactView>
    {
        public ContactModel(IContactRepo r, ApplicationDbContext context) : base(r, context)
        {
        }

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
