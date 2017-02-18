using System;

using SalaryCalculator.Mvp.Models.Reports;
using SalaryCalculator.Mvp.Views.Reports;

namespace SalaryCalculator.Tests.Mocks
{
    public class FakeNonLaborView : IReportNonLaborView
    {
        public ReportNonLaborModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler GetAllNonLaborContracts;
        public event EventHandler Load;
    }
}
