using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.Settings;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Settings
{
    [PresenterBinding(typeof(SettingsLaborContractsPresenter))]
    public partial class Administrator : MvpPage<SettingsLaborContractsModel>, ISettingsLaborContractsView
    {
        public event EventHandler<EventArgs> GetAllLaborContracts;
        public event EventHandler<ModelIdEventArgs> UpdateModel;
        public event EventHandler<ModelIdEventArgs> DeleteModel;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<EmployeePaycheck> AllLaborContracts_GetData()
        {
            this.GetAllLaborContracts?.Invoke(this, new EventArgs());

            return this.Model.LaborContracts.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LaborContracts_UpdateContract(int id)
        {
            this.UpdateModel?.Invoke(this, new ModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LaborContracts_DeleteContract(int id)
        {
            this.DeleteModel?.Invoke(this, new ModelIdEventArgs(id));
        }
    }
}