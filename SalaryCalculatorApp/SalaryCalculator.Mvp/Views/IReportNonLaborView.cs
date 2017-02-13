using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface IReportNonLaborView : IView<ReportNonLaborModel>
    {
        event EventHandler<EventArgs> GetAllNonLaborContracts;
    }
}
