using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Mvp.Presenters.Settings
{
    public class SettingsFreelanceContractsPresenter : Presenter<ISettingsFreelanceContractsView>, ISettingsFreelanceContractsPresenter
    {
        private readonly ISelfEmploymentService selfEmploymentService;

        public SettingsFreelanceContractsPresenter(ISettingsFreelanceContractsView view, ISelfEmploymentService selfEmploymentService) 
            : base(view)
        {
            Guard.WhenArgument<ISelfEmploymentService>(selfEmploymentService, "selfEmploymentService")
                 .IsNull()
                 .Throw();

            this.selfEmploymentService = selfEmploymentService;

            this.View.GetAllFreelanceContracts += GetAllFreelanceContracts;
            this.View.UpdateModel += View_UpdateSelfEmployment;
            this.View.DeleteModel += View_DeleteSelfEmployment;
        }

        public void View_DeleteSelfEmployment(object sender, ModelIdEventArgs e)
        {
            this.selfEmploymentService.DeleteById(e.Id);
        }

        public void View_UpdateSelfEmployment(object sender, ModelIdEventArgs e)
        {
            SelfEmployment selfEmployment = this.selfEmploymentService.GetById(e.Id);
            if (selfEmployment == null)
            {
                this.View.ModelState.
                    AddModelError("", String.Format("SelfEmployment with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(selfEmployment);
            if (this.View.ModelState.IsValid)
            {
                this.selfEmploymentService.UpdateById(e.Id, selfEmployment);
            }
        }

        public void GetAllFreelanceContracts(object sender, EventArgs e)
        {
            this.View.Model.FreelanceContracts = this.selfEmploymentService.GetAll();
        }
    }
}
