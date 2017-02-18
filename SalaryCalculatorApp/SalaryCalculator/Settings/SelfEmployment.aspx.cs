using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.Settings;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Settings
{
    [PresenterBinding(typeof(SettingsFreelanceContractsPresenter))]
    public partial class SelfEmployment : MvpPage<SettingsFreelanceContractsModel>, ISettingsFreelanceContractsView
    {
        public event EventHandler<EventArgs> GetAllFreelanceContracts;
        public event EventHandler<ModelIdEventArgs> DeleteModel;
        public event EventHandler<ModelIdEventArgs> UpdateModel;

        public IQueryable<SalaryCalculator.Data.Models.SelfEmployment> FreelanceContracts_GetData()
        {
            this.GetAllFreelanceContracts?.Invoke(this, new EventArgs());

            return this.Model.FreelanceContracts.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FreelanceContracts_UpdateContract(int id)
        {
            this.UpdateModel?.Invoke(this, new ModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FreelanceContracts_DeleteContract(int id)
        {
            this.DeleteModel?.Invoke(this, new ModelIdEventArgs(id));
        }
    }
}