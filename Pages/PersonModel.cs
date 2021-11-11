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
    public class PersonModel : ViewedModel<Person, PersonView>
    {
        //TODO: Concurrency pls
        public PersonModel(IPersonRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override PersonView ToView(Person obj)
        {
            PersonView view = new PersonView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal override Person ToEntity(PersonView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new PersonData());
            return new Person(data);
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
