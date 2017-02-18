using System;

using SalaryCalculator.Mvp.Models.Reports;
using SalaryCalculator.Mvp.Views.Reports;

namespace SalaryCalculator.Tests.Mocks
{
    public class FakeLaborView : IReportLaborView
    {
        public ReportLaborModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler GetAllLaborContracts;
        public event EventHandler Load;
    }
}
