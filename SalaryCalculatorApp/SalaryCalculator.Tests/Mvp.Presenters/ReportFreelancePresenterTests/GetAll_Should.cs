using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Mvp.Views.Reports;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters.ReportFreelancePresenterTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAll_ShouldInvokeOnce_WhenIsCalled()
        {
            var view = new Mock<IReportFreelanceView>();
            var service = new Mock<ISelfEmploymentService>();

            var presenter = new ReportFreelancePresenter(view.Object, service.Object);
            var eventArgs = new Mock<EventArgs>();

            var contracts = new List<FakeSelfEmployment>() { new FakeSelfEmployment() };
            view.Setup(x => x.Model.FreelanceContracts).Returns(contracts).Verifiable();
            service.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            view.Raise(x => x.GetAllFreelanceContracts += null, eventArgs.Object);

            service.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
