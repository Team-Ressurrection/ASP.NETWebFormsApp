using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.ReportNonLaborPresenterTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAll_ShouldInvokeOnce_WhenIsCalled()
        {
            var view = new FakeNonLaborView();
            var service = new Mock<IRemunerationBillService>();

            var presenter = new ReportNonLaborPresenter(view, service.Object);
            var eventArgs = new Mock<EventArgs>();

            var contracts = new List<FakeRemunerationBill>() { new FakeRemunerationBill() };
            view.Model.NonLaborContracts = contracts;
            service.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            presenter.GetAll(new object { }, eventArgs.Object);

            service.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
