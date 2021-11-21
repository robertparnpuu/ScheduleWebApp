﻿using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using PageModels.Common;

namespace PageModels
{
    public class PersonModel : WithContactModel<Person,PersonView>
    {
        public PersonModel(IPersonRepo r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a, 
        ApplicationDbContext context) : base(r,pc,c,a, context)
        { }
        public override string PageTitle => "Persons";
        protected internal override PersonView ToView(Person obj)
        {
            PersonView view = new PersonView();
            Copy.Members(obj, view);
            view.fullName = obj?.fullName;
            return view;
        }
        //TODO 9. siia vaja filtrid
        protected internal override Person ToEntity(PersonView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new PersonData());
            return new Person(data);
        }
    }
}
