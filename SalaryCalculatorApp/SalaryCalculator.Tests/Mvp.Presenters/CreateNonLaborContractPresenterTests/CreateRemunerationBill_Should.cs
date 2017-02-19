using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
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
            var billService = new Mock<IRemunerationBillService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var presenter = new CreateNonLaborContractPresenter(view.Object, billService.Object,employeeService.Object,modelFactory.Object, calculate);
            var obj = new object { };
            var salary = new decimal();
            var e = new Mock<RemunerationBillEventArgs>(salary);
            var bill = new FakeRemunerationBill();
            view.SetupGet(x => x.Model.RemunerationBill).Returns(bill);

            presenter.CreateRemunerationBill(obj, e.Object);

            billService.Verify(x => x.Create(bill), Times.Once);
        }

        [Test]
        public void CreateRemunerationBill_ShouldThrowArgumentNullException()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var billService = new Mock<IRemunerationBillService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();
            
            var obj = new object { };
            var salary = new decimal();
            var e = new Mock<RemunerationBillEventArgs>(salary);
            FakeRemunerationBill bill = null;
            view.SetupGet(x => x.Model.RemunerationBill).Returns(bill);

            var presenter = new CreateNonLaborContractPresenter(view.Object, billService.Object, employeeService.Object, modelFactory.Object, calculate);

            Assert.Throws<ArgumentNullException>(() => presenter.CreateRemunerationBill(obj, e.Object));
        }
    }
}
