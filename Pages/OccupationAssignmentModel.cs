﻿using System.Linq;
using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PageModels.Common;

namespace PageModels
{
    public class OccupationAssignmentModel : BaseModel<OccupationAssignment, OccupationAssignmentView>
    {
        //TODO: Concurrency pls
        public OccupationAssignmentModel(IOccupationAssignmentRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override OccupationAssignmentView ToView(OccupationAssignment obj)
        {
            OccupationAssignmentView view = new OccupationAssignmentView();
            Copy.Members(obj, view);
            view.occupationName = obj.occupation?.name;
            view.personName = obj.person?.fullName;
            view.departmentName = obj.department?.name;
            return view;
        }

        protected internal override OccupationAssignment ToEntity(OccupationAssignmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new OccupationAssignmentData());
            return new OccupationAssignment(data);
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