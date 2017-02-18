using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Mvp.Presenters.Settings
{
    public class SettingsLaborContractsPresenter : Presenter<ISettingsLaborContractsView>, ISettingsLaborContractsPresenter
    {
        private readonly IEmployeePaycheckService paycheckService;

        public SettingsLaborContractsPresenter(ISettingsLaborContractsView view, IEmployeePaycheckService paycheckService) 
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService")
                 .IsNull()
                 .Throw();

            this.paycheckService = paycheckService;

            this.View.GetAllLaborContracts += GetAllLaborContracts;
            this.View.UpdateModel += View_UpdatePaycheck;
            this.View.DeleteModel += View_DeletePaycheck;
        }

        private void View_DeletePaycheck(object sender, IModelIdEventArgs e)
        {
            this.paycheckService.DeleteById(e.Id);
        }

        private void View_UpdatePaycheck(object sender, IModelIdEventArgs e)
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

        public void GetAllLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.LaborContracts = this.paycheckService.GetAll();
        }
    }
}
