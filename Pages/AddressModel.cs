using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using PageModels.Common;

namespace PageModels
{
    public class AddressModel : ViewedModel<Address, AddressView>
    {
        public AddressModel(IAddressRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override AddressView ToView(Address obj)
        {
            AddressView view = new AddressView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal override Address ToEntity(AddressView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new AddressData());
            return new Address(data);
        }
    }
}
