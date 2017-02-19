using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateLaborContractPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ICreateLaborContractView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.IsInstanceOf<ICreateLaborContractPresenter>(new CreateLaborContractPresenter(view.Object, paycheckService.Object, employeeService.Object, modelFactory.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenPaycheckServiceParameterIsNull()
        {
            var view = new Mock<ICreateLaborContractView>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateLaborContractPresenter(view.Object, null, employeeService.Object, modelFactory.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenEmployeeServiceParameterIsNull()
        {
            var view = new Mock<ICreateLaborContractView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateLaborContractPresenter(view.Object, paycheckService.Object,null, modelFactory.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenModelFactoryParameterIsNull()
        {
            var view = new Mock<ICreateLaborContractView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateLaborContractPresenter(view.Object, paycheckService.Object, employeeService.Object, null, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenCalculateParameterIsNull()
        {
            var view = new Mock<ICreateLaborContractView>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();

            Assert.Throws<ArgumentNullException>(() => new CreateLaborContractPresenter(view.Object, paycheckService.Object, employeeService.Object, modelFactory.Object, null));
        }
    }
}
