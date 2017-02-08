using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface IReportLaborView : IView<ReportLaborModel>
    {
        event EventHandler<EventArgs> GetAll;
    }
}
