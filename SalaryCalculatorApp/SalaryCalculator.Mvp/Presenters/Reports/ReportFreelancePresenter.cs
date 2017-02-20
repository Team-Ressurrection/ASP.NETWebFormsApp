using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views.Reports;

namespace SalaryCalculator.Mvp.Presenters.Reports
{
    public class ReportFreelancePresenter : Presenter<IReportFreelanceView>, IReportFreelancePresenter
    {
        private readonly ISelfEmploymentService selfEmploymentService;

        public ReportFreelancePresenter(IReportFreelanceView view, ISelfEmploymentService selfEmploymentService)
            : base(view)
        {
            Guard.WhenArgument<ISelfEmploymentService>(selfEmploymentService, "selfEmploymentService")
                 .IsNull()
                 .Throw();

            this.selfEmploymentService = selfEmploymentService;
            this.View.GetAllFreelanceContracts += GetAll;
        }

        private void GetAll(object sender, EventArgs e)
        {
            this.View.Model.FreelanceContracts = this.selfEmploymentService.GetAll();
        }
    }
}
