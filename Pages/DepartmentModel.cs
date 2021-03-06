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
    public class DepartmentModel : WithContactModel<Department, DepartmentView>
    {
        public DepartmentModel(IDepartmentRepo r, IPartyContactRepo pc, IContactRepo c, IAddressRepo a,
        ApplicationDbContext context) : base(r, pc, c, a, context) { }
        public override string PageTitle => "Department";
        protected internal override DepartmentView ToView(Department obj)
        {
            DepartmentView view = new DepartmentView();
            Copy.Members(obj, view);
            return view;
        }
        
        protected internal override Department ToEntity(DepartmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new DepartmentData());
            return new Department(data);
        }
    }
}
