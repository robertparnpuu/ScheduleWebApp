using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using PageModels.Common;

namespace PageModels
{
    public class DepartmentModel : WithContactModel<Department, DepartmentView>
    {
        public DepartmentModel(IDepartmentRepo r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a,
        ApplicationDbContext context) : base(r, pc, c, a, context) { }
        public override string PageTitle => "Departments";
        protected internal override DepartmentView ToView(Department obj)
        {
            DepartmentView view = new DepartmentView();
            Copy.Members(obj, view);
            return view;
        }
        //TODO 7. siia vaja filtrid
        protected internal override Department ToEntity(DepartmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new DepartmentData());
            return new Department(data);
        }
    }
}
