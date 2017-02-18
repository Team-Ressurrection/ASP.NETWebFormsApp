using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models.Reports;

namespace SalaryCalculator.Mvp.Views.Reports
{
    public interface IReportFreelanceView : IView<ReportFreelanceModel>
    {
        event EventHandler<EventArgs> GetAllFrelanceContracts;
    }
}
