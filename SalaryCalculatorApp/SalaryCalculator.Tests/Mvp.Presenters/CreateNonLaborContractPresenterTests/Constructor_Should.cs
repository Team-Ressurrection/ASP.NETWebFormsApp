using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Factories;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateNonLaborContractPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var billService = new Mock<IRemunerationBillService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.IsInstanceOf<ICreateNonLaborContractPresenter>(new CreateNonLaborContractPresenter(view.Object, billService.Object, employeeService.Object, modelFactory.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenBillServiceParameterIsNull()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateNonLaborContractPresenter(view.Object, null, employeeService.Object, modelFactory.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenEmployeeServiceParameterIsNull()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var billService = new Mock<IRemunerationBillService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateNonLaborContractPresenter(view.Object, billService.Object, null, modelFactory.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenModelFactoryParameterIsNull()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var billService = new Mock<IRemunerationBillService>();
            var employeeService = new Mock<IEmployeeService>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateNonLaborContractPresenter(view.Object, billService.Object, employeeService.Object, null, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenCalculateParameterIsNull()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var billService = new Mock<IRemunerationBillService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();

            Assert.Throws<ArgumentNullException>(() => new CreateNonLaborContractPresenter(view.Object, billService.Object, employeeService.Object, modelFactory.Object, null));
        }
    }
}
