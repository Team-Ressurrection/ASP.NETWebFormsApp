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

namespace SalaryCalculator.Reports
{
    [PresenterBinding(typeof(ReportLaborPresenter))]
    public partial class Labor : MvpPage<ReportLaborModel>, IReportLaborView
    {
        public event EventHandler<EventArgs> GetAll;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetAll?.Invoke(sender, new EventArgs());
            this.AllLaborContracts.DataSource = this.Model.LaborContracts.ToList();
            this.AllLaborContracts.DataBind();
        }

        protected void AllLaborContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.AllLaborContracts.PageIndex = e.NewPageIndex;
        }
    }
}