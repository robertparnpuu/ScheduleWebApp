using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PageModels.Common;

namespace PageModels
{
    public class WorkerModel : BaseModel<Worker, WorkerView>
    {
        //TODO: Concurrency pls
        public WorkerModel(IWorkerRepo wr,IPersonRepo pr, ApplicationDbContext context) : base(wr, context)
        {
            person = pr;
        }

        internal IPersonRepo person;
        protected internal override WorkerView ToView(Worker obj)
        {
            WorkerView view = new WorkerView();
            Copy.Members(obj, view);
            //view.WorkerEmail = obj.WorkerContact?.email;
            //view.WorkerPhoneNr = obj.WorkerContact?.phoneNumber;
            return view;
        }

        protected internal override Worker ToEntity(WorkerView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new WorkerData());
            return new Worker(data);
        }

        //public SelectList Contacts
        //{
        //    get
        //    {
        //        var list = new GetRepo().Instance<IContactRepo>().GetById();
        //        return new SelectList(list, "id", "email", item?.contactId);
        //    }
        //}
    }
}
