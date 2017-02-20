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
    [PresenterBinding(typeof(ReportFreelancePresenter))]
    public partial class Freelance : MvpPage<ReportFreelanceModel>, IReportFreelanceView
    {
        public event EventHandler GetAllFreelanceContracts;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetAllFreelanceContracts?.Invoke(this, null);
            this.AllFreelanceContracts.DataSource = this.Model.FreelanceContracts.ToList();
            this.AllFreelanceContracts.DataBind();
        }

        protected void AllFreelanceContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.AllFreelanceContracts.PageIndex = e.NewPageIndex;
        }
    }
}