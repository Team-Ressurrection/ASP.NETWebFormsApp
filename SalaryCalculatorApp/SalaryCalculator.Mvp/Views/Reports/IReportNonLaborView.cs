using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models.Reports;

namespace SalaryCalculator.Mvp.Views.Reports
{
    public interface IReportNonLaborView : IView<ReportNonLaborModel>
    {
        event EventHandler GetAllNonLaborContracts;
    }
}
