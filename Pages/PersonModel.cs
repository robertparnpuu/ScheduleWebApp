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
    public class PersonModel : WithContactModel<Person,PersonView>
    {
        public PersonModel(IPersonRepo r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a, 
        ApplicationDbContext context) : base(r,pc,c,a, context)
        { }
        public override string PageTitle => "Person";
        protected internal override PersonView ToView(Person obj)
        {
            PersonView view = new PersonView();
            Copy.Members(obj, view);
            view.fullName = obj?.fullName;
            return view;
        }
        protected internal override Person ToEntity(PersonView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new PersonData());
            return new Person(data);
        }
    }
}
