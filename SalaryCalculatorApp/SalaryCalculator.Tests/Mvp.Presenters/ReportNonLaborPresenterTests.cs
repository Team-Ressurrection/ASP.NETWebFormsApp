using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace SalaryCalculator.Tests.Mvp.Presenters
{
    [TestFixture]
    public class ReportNonLaborPresenterTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParameterServiceIsNull()
        {
            var view = new Mock<IReportNonLaborView>();
            var service = new Mock<IRemunerationBillService>();

            Assert.That(() => new ReportNonLaborPresenter(view.Object, null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Constructor_ShouldCreateInstanceCorrectly_WhenAllParametersArePassed()
        {
            var view = new Mock<IReportNonLaborView>();
            var service = new Mock<IRemunerationBillService>();
            var repo = new Mock<IRepository<RemunerationBill>>();
            var bill = new FakeEmployeePaycheck();

            IReportNonLaborPresenter presenter = new ReportNonLaborPresenter(view.Object, service.Object);

            Assert.IsInstanceOf<IReportNonLaborPresenter>(presenter);
        }

        [Test]
        public void GetAll_ShouldInvokeOnce_WhenIsCalled()
        {
            var view = new FakeNonLaborView();
            var service = new Mock<IRemunerationBillService>();

            var presenter = new ReportNonLaborPresenter(view, service.Object);
            var eventArgs = new Mock<EventArgs>();

            var contracts = new List<FakeRemunerationBill>() { new FakeRemunerationBill()};
            view.Model.NonLaborContracts = contracts;
            service.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            presenter.GetAll(new object { }, eventArgs.Object);

            service.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
