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
    [PresenterBinding(typeof(SettingsNonLaborContractsPresenter))]
    public partial class RemunerationBill : MvpPage<SettingsNonLaborContractsModel>, ISettingsNonLaborContractsView
    {
        public event EventHandler<EventArgs> GetAllNonLaborContracts;
        public event EventHandler<ModelIdEventArgs> DeleteModel;
        public event EventHandler<ModelIdEventArgs> UpdateModel;

        public IQueryable<SalaryCalculator.Data.Models.RemunerationBill> NonLaborContracts_GetData()
        {
            this.GetAllNonLaborContracts?.Invoke(this, new EventArgs());

            return this.Model.NonLaborContracts.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void NonLaborContracts_UpdateContract(int id)
        {
            this.UpdateModel?.Invoke(this, new ModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void NonLaborContracts_DeleteContract(int id)
        {
            this.DeleteModel?.Invoke(this, new ModelIdEventArgs(id));
        }
    }
}