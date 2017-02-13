using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace SalaryCalculator.Tests.Mvp.Presenters
{
    [TestFixture]
    public class ReportLaborPresenterTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParameterServiceIsNull()
        {
            var view = new Mock<IReportLaborView>();
            var service = new Mock<IEmployeePaycheckService>();

            Assert.That(() => new ReportLaborPresenter(view.Object, null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Constructor_ShouldCreateInstanceCorrectly_WhenAllParametersArePassed()
        {
            var view = new Mock<IReportLaborView>();
            var service = new Mock<IEmployeePaycheckService>();

            Assert.IsInstanceOf<IReportLaborPresenter>(new ReportLaborPresenter(view.Object, service.Object));
        }

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
