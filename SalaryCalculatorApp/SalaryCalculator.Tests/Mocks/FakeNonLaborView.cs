using SalaryCalculator.Mvp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.Mvp.Models;

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

        public event EventHandler<EventArgs> GetAllNonLaborContracts;
        public event EventHandler Load;
    }
}
