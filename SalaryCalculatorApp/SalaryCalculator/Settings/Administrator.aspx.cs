using System;
using System.Linq;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Settings
{
    [PresenterBinding(typeof(AdministratorSettingsPresenter))]
    public partial class Administrator : MvpPage<AdministratorSettingsModel>, IAdministratorSettingsView
    {
        public event EventHandler<EventArgs> GetAllFreelanceContracts;
        public event EventHandler<EventArgs> GetAllLaborContracts;
        public event EventHandler<EventArgs> GetAllNonLaborContracts;
        public event EventHandler<ModelIdEventArgs> UpdatePaycheck;
        public event EventHandler<ModelIdEventArgs> DeletePaycheck;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.GetAllNonLaborContracts?.Invoke(sender, new EventArgs());
            //this.AllNonLaborContracts.DataSource = this.Model.NonLaborContracts.ToList();
            //this.AllNonLaborContracts.DataBind();
        }

        public IQueryable<EmployeePaycheck> AllLaborContracts_GetData()
        {
            this.GetAllLaborContracts?.Invoke(this, new EventArgs());

            return this.Model.LaborContracts.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LaborContracts_UpdateContract(int id)
        {
            this.UpdatePaycheck?.Invoke(this, new ModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LaborContracts_DeleteContract(int id)
        {
            this.DeletePaycheck?.Invoke(this, new ModelIdEventArgs(id));
        }
    }
}