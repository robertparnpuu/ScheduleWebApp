using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids;
using Data;
using Domain;
using Domain.Common;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PageModels.Common;

namespace PageModels
{
    public class ScheduleModel : PagedModel<ShiftAssignment, ShiftAssignmentView>
    {
        [BindProperty] public List<StandardShiftView> standardShifts { get; set; }
        [BindProperty] public List<ContractView> contracts { get; set; }
        public override string PageTitle => "Schedule";
        protected readonly IRepo<StandardShift> ssRepo;
        protected readonly IRepo<Contract> cRepo;

        public ScheduleModel(IShiftAssignmentRepo r, IStandardShiftRepo sShiftRepo, IContractRepo contractRepo,
        ApplicationDbContext context) : base(r, context)
        {
            ssRepo = sShiftRepo;
            cRepo = contractRepo;
        }

        public async Task OnGetIndexAsync() =>
        standardShifts = (await ssRepo.GetEntityListAsync()).Select(SSToView).ToList();

        public async Task OnGetSelectDateAsync(string ssId)
        {
            item = new ShiftAssignmentView();
            item.dateChoice = DateTime.Now;
            StandardShiftView ssView = SSToView(await ssRepo.GetEntityAsync(ssId));
            Copy.Members(ssView, item, "dateChoice", "id");

            VMToSession();
        }

        public async Task<IActionResult> OnPostSelectDateAsync()
        {
            //View topib scheduleviewi, ning kasutame VMToSession et scheduleViewist teha edasi antav Json sessionis
            //Hetkel ei leidnud moodust sessionit ise muuta, ehk topin olemasolevad viewi ja siis kirjutan sessioni yle

            Copy.Members(GetSessionObject("shiftAssignment"), item, "dateChoice");
            item.startTime = Combine.DateAndTime(item.dateChoice, item.startTime);
            item.endTime = Combine.DateAndTime(item.dateChoice, item.endTime);
            VMToSession();
            return RedirectToPage("ChooseWorker", new { handler = "ChooseWorker" });
        }

        //TODO, 3. Siit peab kasutama Contractis olevat personit
        public async Task OnGetChooseWorkerAsync()
        {
            item = GetSessionObject("shiftAssignment");
            contracts = (await cRepo.GetEntityListAsync()).Select(ContractToView).ToList();
        }

        public async Task OnGetConfirmAssignmentAsync(string cId)
        {
            item = new ShiftAssignmentView();
            Copy.Members(GetSessionObject("shiftAssignment"), item, "dateChoice");
            ContractView contract = ContractToView(await cRepo.GetEntityAsync(cId));
            item.contractId = contract.id;
            item.personName = contract.personName;

            VMToSession();
        }

        public async Task<IActionResult> OnPostConfirmAssignmentAsync()
        {
            item = GetSessionObject("shiftAssignment");
            ClearAndValidateItemModelState();
            if (!ModelState.IsValid) return Page();
            return await repo.AddAsync(ToEntity(item))
            ? RedirectToPage("./StandardShifts", new { handler = "Index" })
            : Page();
        }

        protected internal void ClearAndValidateItemModelState()
        {
            ModelState.Clear();
            TryValidateModel(item);
        }

        //TODO 11. siia vaja filtrid
        protected internal void VMToSession() =>
        HttpContext.Session.SetObjectAsJson("shiftAssignment", item);

        protected internal ShiftAssignmentView GetSessionObject(string key) =>
        HttpContext.Session.GetObjectFromJson<ShiftAssignmentView>(key);

        protected internal ContractView ContractToView(Contract obj)
        {
            ContractView view = new ContractView();
            Copy.Members(obj, view);
            view.occupationName = obj?.contractOccupation?.name;
            view.personName = obj?.contractPerson?.fullName;
            view.departmentName = obj?.contractDepartment?.name;
            view.fullContact = obj?.contractPerson.partyContact.partyContactContact.contacts;

            return view;
        }

        protected internal StandardShiftView SSToView(StandardShift obj)
        {
            StandardShiftView view = new StandardShiftView();
            Copy.Members(obj, view);
            view.locationName = obj?.shiftLocation?.name;
            view.occupationName = obj?.shiftOccupation?.name;
            return view;
        }

        protected internal override ShiftAssignmentView ToView(ShiftAssignment obj)
        {
            ShiftAssignmentView view = new ShiftAssignmentView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal override ShiftAssignment ToEntity(ShiftAssignmentView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new ShiftAssignmentData());
            return new ShiftAssignment(data);
        }

        public SelectList Contracts
        {
            get
            {
                var list = new GetRepo().Instance<IContractRepo>().GetById();
                return new SelectList(list, "id", "personName", item?.contractId);
            }
        }

        public SelectList Locations
        {
            get
            {
                var list = new GetRepo().Instance<ILocationRepo>().GetById();
                return new SelectList(list, "id", "name", item?.locationId);

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
    }
} 