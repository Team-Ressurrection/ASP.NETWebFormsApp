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

namespace SalaryCalculator.Settings
{
    [PresenterBinding(typeof(AdministratorSettingsPresenter))]
    public partial class Administrator : MvpPage<AdministratorSettingsModel>, IAdministratorSettingsView
    {
        public event EventHandler<EventArgs> GetAllFreelanceContracts;
        public event EventHandler<EventArgs> GetAllLaborContracts;
        public event EventHandler<EventArgs> GetAllNonLaborContracts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetAllLaborContracts?.Invoke(sender, new EventArgs());
            this.AllLaborContracts.DataSource = this.Model.LaborContracts.ToList();
            this.AllLaborContracts.DataBind();

            this.GetAllNonLaborContracts?.Invoke(sender, new EventArgs());
            this.AllNonLaborContracts.DataSource = this.Model.NonLaborContracts.ToList();
            this.AllNonLaborContracts.DataBind();
        }

        protected void AllLaborContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // TODO:
        }

        protected void AllNonLaborContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // TODO:
        }
    }
}