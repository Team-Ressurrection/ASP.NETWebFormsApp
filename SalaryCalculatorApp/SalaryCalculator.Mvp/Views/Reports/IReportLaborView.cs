using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models.Reports;

namespace SalaryCalculator.Mvp.Views.Reports
{
    public interface IReportLaborView : IView<ReportLaborModel>
    {
        event EventHandler<EventArgs> GetAllLaborContracts;
    }
}
