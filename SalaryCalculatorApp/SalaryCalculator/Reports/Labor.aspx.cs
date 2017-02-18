using SalaryCalculator.Mvp.Models.Reports;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Mvp.Views.Reports;
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
        public event EventHandler GetAllLaborContracts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetAllLaborContracts?.Invoke(this, null);
            this.AllLaborContracts.DataSource = this.Model.LaborContracts.ToList();
            this.AllLaborContracts.DataBind();
        }

        protected void AllLaborContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.AllLaborContracts.PageIndex = e.NewPageIndex;
        }
    }
}