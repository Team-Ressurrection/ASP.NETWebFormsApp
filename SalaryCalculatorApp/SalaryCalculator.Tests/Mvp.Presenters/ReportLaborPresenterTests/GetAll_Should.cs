using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Mvp.Views.Reports;

namespace SalaryCalculator.Tests.Mvp.Presenters.ReportLaborPresenterTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAll_ShouldInvokeOnce_WhenIsCalled()
        {
            var view = new Mock<IReportLaborView>();
            var service = new Mock<IEmployeePaycheckService>();

            var presenter = new ReportLaborPresenter(view.Object, service.Object);
            var eventArgs = new Mock<EventArgs>();

            var contracts = new List<FakeEmployeePaycheck>() { new FakeEmployeePaycheck() };
            view.Setup(x => x.Model.LaborContracts).Returns(contracts);
            service.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            view.Raise(x => x.GetAllLaborContracts += null, eventArgs.Object);

            service.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
