using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views.Reports;

namespace SalaryCalculator.Mvp.Presenters.Reports
{
    public class ReportLaborPresenter : Presenter<IReportLaborView>, IReportLaborPresenter
    {
        private readonly IEmployeePaycheckService paycheckService;

        public ReportLaborPresenter(IReportLaborView view, IEmployeePaycheckService paycheckService)
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService")
                 .IsNull()
                 .Throw();

            this.paycheckService = paycheckService;
            this.View.GetAllLaborContracts += GetAll;
        }

        public void GetAll(object sender, System.EventArgs e)
        {
            this.View.Model.LaborContracts = this.paycheckService.GetAll();
        }
    }
}
