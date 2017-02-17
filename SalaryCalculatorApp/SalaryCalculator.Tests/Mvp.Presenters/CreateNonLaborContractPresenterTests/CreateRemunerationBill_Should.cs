using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateNonLaborContractPresenterTests
{
    [TestFixture]
    public class CreateRemunerationBill_Should
    {
        [Test]
        public void CreateRemunerationBill_ShouldPassWithoutError()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var service = new Mock<IRemunerationBillService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var presenter = new CreateNonLaborContractPresenter(view.Object, service.Object,modelFactory.Object, calculate);
            var obj = new object { };
            var salary = new decimal();
            var e = new Mock<RemunerationBillEventArgs>(salary);
            var bill = new FakeRemunerationBill();
            view.SetupGet(x => x.Model.RemunerationBill).Returns(bill);

            presenter.CreateRemunerationBill(obj, e.Object);

            service.Verify(x => x.Create(bill), Times.Once);
        }

        [Test]
        public void CreateRemunerationBill_ShouldThrowArgumentNullException()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var service = new Mock<IRemunerationBillService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var presenter = new CreateNonLaborContractPresenter(view.Object, service.Object, modelFactory.Object,calculate);
            var obj = new object { };
            var salary = new decimal();
            var e = new Mock<RemunerationBillEventArgs>(salary);
            FakeRemunerationBill bill = null;
            view.SetupGet(x => x.Model.RemunerationBill).Returns(bill);

            Assert.Throws<ArgumentNullException>(() => presenter.CreateRemunerationBill(obj, e.Object));
        }
    }
}
