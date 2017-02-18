using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Presenters
{
    public class AdministratorSettingsPresenter : Presenter<IAdministratorSettingsView>, IAdministratorSettingsPresenter
    {
        private readonly IEmployeePaycheckService paycheckService;
        private readonly IRemunerationBillService remunerationBillService;
        private readonly ISelfEmploymentService selfEmploymentService;

        public AdministratorSettingsPresenter(IAdministratorSettingsView view, IEmployeePaycheckService paycheckService, IRemunerationBillService remunerationBillService, ISelfEmploymentService selfEmploymentService) 
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService")
                 .IsNull()
                 .Throw();

            Guard.WhenArgument<IRemunerationBillService>(remunerationBillService, "remunerationBillService")
                 .IsNull()
                 .Throw();

            Guard.WhenArgument<ISelfEmploymentService>(selfEmploymentService, "selfEmploymentService")
                 .IsNull()
                 .Throw();

            this.paycheckService = paycheckService;
            this.remunerationBillService = remunerationBillService;
            this.selfEmploymentService = selfEmploymentService;

            this.View.GetAllFreelanceContracts += GetAllFrelanceContracts; ;
            this.View.GetAllLaborContracts += GetAllLaborContracts;
            this.View.GetAllNonLaborContracts += GetAllNonLaborContracts;
            this.View.UpdatePaycheck += View_UpdatePaycheck;
            this.View.DeletePaycheck += View_DeletePaycheck;
        }

        private void View_DeletePaycheck(object sender, ModelIdEventArgs e)
        {
            this.paycheckService.DeleteById(e.Id);
        }

        private void View_UpdatePaycheck(object sender, ModelIdEventArgs e)
        {
            EmployeePaycheck paycheck = this.paycheckService.GetById(e.Id);
            if (paycheck == null)
            {
                this.View.ModelState.
                    AddModelError("", String.Format("EmployeePaycheck with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(paycheck);
            if (this.View.ModelState.IsValid)
            {
                this.paycheckService.UpdateById(e.Id,paycheck);
            }
        }

        public void GetAllFrelanceContracts(object sender, EventArgs e)
        {
            this.View.Model.FreelanceContracts = this.selfEmploymentService.GetAll();
        }

        public void GetAllNonLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.NonLaborContracts = this.remunerationBillService.GetAll();
        }

        public void GetAllLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.LaborContracts = this.paycheckService.GetAll();
        }
    }
}
