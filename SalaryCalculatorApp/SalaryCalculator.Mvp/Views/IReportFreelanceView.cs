using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface IReportFreelanceView : IView<ReportFreelanceModel>
    {
        event EventHandler<EventArgs> GetAllFrelanceContracts;
    }
}
