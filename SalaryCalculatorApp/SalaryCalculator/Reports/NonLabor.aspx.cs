using System;
using System.Linq;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Reports
{
    [PresenterBinding(typeof(ReportNonLaborPresenter))]
    public partial class NonLabor : MvpPage<ReportNonLaborModel>, IReportNonLaborView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AllNonLaborContracts.DataSource = this.Model.NonLaborContracts.ToList();
            this.AllNonLaborContracts.DataBind();
        }
    }
}