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
    public class DepartmentModel : BaseModel<Department, DepartmentView>
    {
        //TODO: Concurrency pls
        public DepartmentModel(IDepartmentRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override DepartmentView ToView(Department obj)
        {
            DepartmentView view = new DepartmentView();
            Copy.Members(obj, view);
            view.departmentEmail = obj.departmentContact?.email;
            view.departmentPhoneNr = obj.departmentContact?.phoneNumber;
            return view;
        }

        protected internal override Department ToEntity(DepartmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new DepartmentData());
            return new Department(data);
        }

        public SelectList Contacts
        { 
            get
            {
                var list = new GetRepo().Instance<IContactRepo>().GetById();
                return new SelectList(list, "id", "email", item?.contactId);
            }
        }
    }
}
