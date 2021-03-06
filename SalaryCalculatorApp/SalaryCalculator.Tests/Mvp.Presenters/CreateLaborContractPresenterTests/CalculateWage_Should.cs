﻿using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Factories;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateLaborContractPresenterTests
{
    [TestFixture]
    public class CalculateWage_Should
    {
        [TestCase(-10, 10, -10)]
        [TestCase(10, -10, -10)]
        [TestCase(-10, -10, 10)]
        [TestCase(-10, 10, 10)]
        [TestCase(10, -10, 10)]
        [TestCase(10, 10, -10)]
        public void CalculateWage_ShouldThrowException_WhenEventArgsParamIsLessThanZero(decimal obj1, decimal obj2, decimal obj3)
        {
            var view = new Mock<ICreateLaborContractView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var e = new Mock<IPaycheckEventArgs>();
            e.Setup(x => x.GrossSalary).Returns(obj1);
            e.Setup(x => x.GrossFixedBonus).Returns(obj2);
            e.Setup(x => x.GrossNonFixedBonus).Returns(obj3);
            modelFactory.Setup(x => x.GetEmployeePaycheck()).Returns(new FakeEmployeePaycheck());

            var presenter = new CreateLaborContractPresenter(view.Object, paycheckService.Object, employeeService.Object, modelFactory.Object, calculate);

            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.CalculatePaycheck(new object { }, e.Object));
        }

        [TestCase(2000, 100, 1000)]
        public void CalculateWage_ShouldSetPaycheckSocialSecurityIncomeCorrectly_WhenAllEventArgsParamsArePassedCorrectly(decimal obj1, decimal obj2, decimal obj3)
        {
            var view = new Mock<ICreateLaborContractView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();
            var e = new Mock<IPaycheckEventArgs>();

            view.SetupProperty(x => x.Model.EmployeePaycheck, new FakeEmployeePaycheck());
            view.SetupProperty(x => x.Model.Employee, new FakeEmployee() { Id = 1 });
            e.Setup(x => x.GrossSalary).Returns(obj1);
            e.Setup(x => x.GrossFixedBonus).Returns(obj2);
            e.Setup(x => x.GrossNonFixedBonus).Returns(obj3);
            modelFactory.Setup(x => x.GetEmployeePaycheck()).Returns(new FakeEmployeePaycheck());

            var presenter = new CreateLaborContractPresenter(view.Object, paycheckService.Object, employeeService.Object, modelFactory.Object, calculate);

            presenter.CalculatePaycheck(new object { }, e.Object);

            Assert.AreEqual(2600, view.Object.Model.EmployeePaycheck.SocialSecurityIncome);
        }

        [TestCase(2000, 100, 100)]
        [TestCase(2599.99, 0, 0)]
        [TestCase(200, 100, 2200)]
        [TestCase(200, 2100, 100)]
        [TestCase(2100, 100, 100)]
        [TestCase(500, 100, 50)]
        public void CalculateWage_ShouldSetPaycheckSocialSecurityEqualToGrossSalary_WhenAllEventArgsParamsArePassedWithValueLessThan2600(decimal obj1, decimal obj2, decimal obj3)
        {
            var view = new Mock<ICreateLaborContractView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var e = new Mock<IPaycheckEventArgs>();

            view.SetupProperty(x => x.Model.EmployeePaycheck, new FakeEmployeePaycheck());
            view.SetupProperty(x => x.Model.Employee, new FakeEmployee() { Id = 1 });
            modelFactory.Setup(x => x.GetEmployeePaycheck()).Returns(new FakeEmployeePaycheck());
            e.Setup(x => x.GrossSalary).Returns(obj1);
            e.Setup(x => x.GrossFixedBonus).Returns(obj2);
            e.Setup(x => x.GrossNonFixedBonus).Returns(obj3);

            var presenter = new CreateLaborContractPresenter(view.Object, paycheckService.Object, employeeService.Object, modelFactory.Object, calculate);

            presenter.CalculatePaycheck(new object { }, e.Object);

            var expectedGrossSalary = obj1 + obj2 + obj3;

            Assert.AreEqual(expectedGrossSalary, view.Object.Model.EmployeePaycheck.SocialSecurityIncome);
        }

        [TestCase(2000, 1100, 100)]
        [TestCase(2599.99, 0.02, 0)]
        [TestCase(200, 1100, 1300.01)]
        [TestCase(200, 2100, 4100)]
        [TestCase(2601, 0, 0)]
        [TestCase(0, 100, 2601)]
        public void CalculateWage_ShouldSetPaycheckSocialSecurityEqualTo2600_WhenAllEventArgsParamsArePassedWithValueMoreThan2600(decimal obj1, decimal obj2, decimal obj3)
        {
            var view = new Mock<ICreateLaborContractView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();
            var e = new Mock<IPaycheckEventArgs>();

            view.SetupProperty(x => x.Model.EmployeePaycheck, new FakeEmployeePaycheck());
            view.SetupProperty(x => x.Model.Employee, new FakeEmployee() { Id = 1 });
            e.Setup(x => x.GrossSalary).Returns(obj1);
            e.Setup(x => x.GrossFixedBonus).Returns(obj2);
            e.Setup(x => x.GrossNonFixedBonus).Returns(obj3);
            modelFactory.Setup(x => x.GetEmployeePaycheck()).Returns(new FakeEmployeePaycheck());

            var presenter = new CreateLaborContractPresenter(view.Object, paycheckService.Object, employeeService.Object, modelFactory.Object, calculate);

            presenter.CalculatePaycheck(new object { }, e.Object);

            Assert.AreEqual(ValidationConstants.MaxSocialSecurityIncome, view.Object.Model.EmployeePaycheck.SocialSecurityIncome);
        }
    }
}
