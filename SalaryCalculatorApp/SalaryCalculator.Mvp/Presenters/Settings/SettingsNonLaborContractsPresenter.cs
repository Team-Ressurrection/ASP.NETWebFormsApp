using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Mvp.Presenters.Settings
{
    public class SettingsNonLaborContractsPresenter : Presenter<ISettingsNonLaborContractsView>, ISettingsNonLaborContractsPresenter
    {
        private readonly IRemunerationBillService remunerationBillService;

        public SettingsNonLaborContractsPresenter(ISettingsNonLaborContractsView view, IRemunerationBillService remunerationBillService) 
            : base(view)
        {
            Guard.WhenArgument<IRemunerationBillService>(remunerationBillService, "remunerationBillService")
                 .IsNull()
                 .Throw();

            this.remunerationBillService = remunerationBillService;

            this.View.GetAllNonLaborContracts += GetAllNonLaborContracts;
            this.View.UpdateModel += View_UpdateRemunerationBill;
            this.View.DeleteModel += View_DeleteRemunerationBill;
        }

        public void View_DeleteRemunerationBill(object sender, ModelIdEventArgs e)
        {
            this.remunerationBillService.DeleteById(e.Id);
        }

        public void View_UpdateRemunerationBill(object sender, ModelIdEventArgs e)
        {
            RemunerationBill bill = this.remunerationBillService.GetById(e.Id);
            if (bill == null)
            {
                this.View.ModelState.
                    AddModelError("", String.Format("RemunerationBill with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(bill);
            if (this.View.ModelState.IsValid)
            {
                this.remunerationBillService.UpdateById(e.Id, bill);
            }
        }

        public void GetAllNonLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.NonLaborContracts = this.remunerationBillService.GetAll();
        }
    }
}
