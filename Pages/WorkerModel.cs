﻿using System.Linq;
using System.Threading.Tasks;
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
    public class WorkerModel : BaseModel<Worker, WorkerView>
    {
        //TODO: Concurrency pls
        public WorkerModel(IWorkerRepo wr,IPersonRepo pr, ApplicationDbContext context) : base(wr, context)
        {
            person = pr;
        }

        internal IPersonRepo person;
        protected internal override WorkerView ToView(Worker objWorker)
        {
            WorkerView view = new WorkerView();
            Copy.Members(objWorker, view); 
            
            return view;
        }

        protected internal WorkerView ToViewPerson(Worker obj)
        {
            WorkerView view = ToView(obj);
            Person p = person.GetEntity(obj.personId);
            view = PersonToView(p,view);
            return view;
        }
        public override async Task OnGetIndexAsync() => items = (await repo.GetEntityListAsync()).Select(ToViewPerson).ToList();
        protected internal override async Task<bool> GetItemAsync(string id)
        {
            if (id == null) return false;
            Worker w = (await repo.GetEntityAsync(id));
            item = ToView(w);
            Person p = await person.GetEntityAsync(item.personId);
            item = PersonToView(p, item);
            return item != null && item.id != "Unspecified";
        }

        protected internal WorkerView PersonToView(Person objPerson, WorkerView view)
        {
            Copy.Members(objPerson, view,"id");
            return view;
        }

        protected internal override Worker ToEntity(WorkerView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new WorkerData());
            return new Worker(data);
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
