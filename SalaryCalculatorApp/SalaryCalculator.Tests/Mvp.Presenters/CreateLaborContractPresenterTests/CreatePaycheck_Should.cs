﻿using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateLaborContractPresenterTests
{
    [TestFixture]
    public class CreatePaycheck_Should
    {
        [Test]
        public void CreatePaycheck_ShouldPassWithoutError()
        {
            var view = new Mock<ICreateLaborContractView>();
            var service = new Mock<IEmployeePaycheckService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var presenter = new CreateLaborContractPresenter(view.Object, service.Object, modelFactory.Object, calculate);
            var obj = new object { };
            var salary = new decimal();
            var e = new Mock<PaycheckEventArgs>(salary, salary, salary);
            var paycheck = new FakeEmployeePaycheck();
            view.SetupGet(x => x.Model.EmployeePaycheck).Returns(paycheck);

            presenter.CreatePaycheck(obj, e.Object);

            service.Verify(x => x.Create(paycheck), Times.Once);
        }

        [Test]
        public void CreatePaycheck_ShouldThrowArgumentNullException()
        {
            var view = new Mock<ICreateLaborContractView>();
            var service = new Mock<IEmployeePaycheckService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var presenter = new CreateLaborContractPresenter(view.Object, service.Object, modelFactory.Object,calculate);
            var obj = new object { };
            var salary = new decimal();
            var e = new Mock<PaycheckEventArgs>(salary, salary, salary);
            FakeEmployeePaycheck paycheck = null;
            view.SetupGet(x => x.Model.EmployeePaycheck).Returns(paycheck);

            Assert.Throws<ArgumentNullException>(() => presenter.CreatePaycheck(obj, e.Object));
        }
    }
}
