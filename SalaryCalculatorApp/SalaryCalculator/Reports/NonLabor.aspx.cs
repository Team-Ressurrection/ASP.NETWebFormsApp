using System;
using System.Linq;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.Models.Reports;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Mvp.Views.Reports;

namespace SalaryCalculator.Reports
{
    [PresenterBinding(typeof(ReportNonLaborPresenter))]
    public partial class NonLabor : MvpPage<ReportNonLaborModel>, IReportNonLaborView
    {
        public event EventHandler<EventArgs> GetAllNonLaborContracts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetAllNonLaborContracts?.Invoke(sender, e);

            this.AllNonLaborContracts.DataSource = this.Model.NonLaborContracts.ToList();
            this.AllNonLaborContracts.DataBind();
        }

        protected void AllNonLaborContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.AllNonLaborContracts.PageIndex = e.NewPageIndex;
        }
    }
}