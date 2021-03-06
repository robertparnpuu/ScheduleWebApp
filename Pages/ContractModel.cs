using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PageModels.Common;

namespace PageModels
{
    [Authorize(Roles = "Admin,Manager")]
    public class ContractModel : ViewModel<Contract, ContractView>
    {
        public ContractModel(IContractRepo r, ApplicationDbContext context) : base(r, context) { }
        public override string PageTitle => "Contract";
        protected internal override ContractView ToView(Contract obj)
        {
            ContractView view = new ContractView();
            Copy.Members(obj, view);
            view.occupationName = obj?.contractOccupation?.name;
            view.personName = obj?.contractPerson?.fullName;
            view.departmentName = obj?.contractDepartment?.name;

            return view;
        }
        protected internal override Contract ToEntity(ContractView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ContractData());
            return new Contract(data);
        }

        public SelectList Persons
        {
            get
            {
                var list = new GetRepo().Instance<IPersonRepo>().GetById();
                return new SelectList(list, "id", "fullName", item?.personId);
            }
        }

        public SelectList Occupations
        {
            get
            {
                var list = new GetRepo().Instance<IOccupationRepo>().GetById();
                return new SelectList(list, "id", "name", item?.occupationId);
            }
        }

        public SelectList Departments
        {
            get
            {
                var list = new GetRepo().Instance<IDepartmentRepo>().GetById();
                return new SelectList(list, "id", "name", item?.departmentId);
            }
        }
    }
}