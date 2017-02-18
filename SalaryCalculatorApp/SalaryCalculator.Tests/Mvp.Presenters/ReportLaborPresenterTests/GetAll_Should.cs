using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.ReportLaborPresenterTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAll_ShouldInvokeOnce_WhenIsCalled()
        {
            var view = new FakeLaborView();
            var service = new Mock<IEmployeePaycheckService>();

            var presenter = new ReportLaborPresenter(view, service.Object);
            var eventArgs = new Mock<EventArgs>();

            var contracts = new List<FakeEmployeePaycheck>() { new FakeEmployeePaycheck() };
            view.Model.LaborContracts = contracts;
            service.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            presenter.GetAll(new object { }, eventArgs.Object);

            service.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
