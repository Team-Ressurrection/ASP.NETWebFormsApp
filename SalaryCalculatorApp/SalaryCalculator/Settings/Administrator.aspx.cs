using SalaryCalculator.Data.Models;
using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Settings
{
    [PresenterBinding(typeof(AdministratorSettingsPresenter))]
    public partial class Administrator : MvpPage<AdministratorSettingsModel>, IAdministratorSettingsView
    {
        public event EventHandler<EventArgs> GetAllFreelanceContracts;
        public event EventHandler<EventArgs> GetAllLaborContracts;
        public event EventHandler<EventArgs> GetAllNonLaborContracts;
        public event EventHandler<ModelIdEventArgs> UpdatePaycheck;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.GetAllNonLaborContracts?.Invoke(sender, new EventArgs());
            //this.AllNonLaborContracts.DataSource = this.Model.NonLaborContracts.ToList();
            //this.AllNonLaborContracts.DataBind();
        }

        protected void View_AllLaborContracts(object sender, EventArgs e)
        {

        }

        protected void AllLaborContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // TODO:
        }

        protected void AllNonLaborContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // TODO:
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
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
    }
}