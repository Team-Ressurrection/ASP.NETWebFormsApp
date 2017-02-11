using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters
{
    [TestFixture]
    public class CreateLaborContractPresenterTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ICreateLaborContractView>();
            var service = new Mock<IEmployeePaycheckService>();

            Assert.IsInstanceOf<ICreateLaborContractPresenter>(new CreateLaborContractPresenter(view.Object, service.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenServiceParameterIsNull()
        {
            var view = new Mock<ICreateLaborContractView>();

            Assert.Throws<ArgumentNullException>(() => new CreateLaborContractPresenter(view.Object, null));
        }

        [Test]
        public void CreatePaycheck_ShouldPassWithoutError()
        {
            var view = new Mock<ICreateLaborContractView>();
            var service = new Mock<IEmployeePaycheckService>();

            var presenter = new CreateLaborContractPresenter(view.Object, service.Object);
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

            var presenter = new CreateLaborContractPresenter(view.Object, service.Object);
            var obj = new object { };
            var salary = new decimal();
            var e = new Mock<PaycheckEventArgs>(salary, salary, salary);
            FakeEmployeePaycheck paycheck = null;
            view.SetupGet(x => x.Model.EmployeePaycheck).Returns(paycheck);

            Assert.Throws<ArgumentNullException>(() => presenter.CreatePaycheck(obj, e.Object));
        }

        [TestCase(-10,10,-10)]
        [TestCase(10,-10,-10)]
        [TestCase(-10,-10,10)]
        [TestCase(-10,10,10)]
        [TestCase(10,-10,10)]
        [TestCase(10,10, -10)]
        public void CalculateWage_ShouldThrowException_WhenEventArgsParamIsLessThanZero(decimal obj1, decimal obj2, decimal obj3)
        {
            var view = new Mock<ICreateLaborContractView>();
            var service = new Mock<IEmployeePaycheckService>();

            var presenter = new CreateLaborContractPresenter(view.Object, service.Object);
            var e = new Mock<PaycheckEventArgs>(obj1,obj2,obj3);

            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.CalculatePaycheck(new object { }, e.Object));
        }

        [TestCase(1000, 100, 150)]
        public void CalculateWage_ShouldSetPaycheckCorrectlyToViewModel_WhenAllEventArgsParamsArePassedCorrectly(decimal obj1, decimal obj2, decimal obj3)
        {
            var view = new Mock<ICreateLaborContractView>();
            var service = new Mock<IEmployeePaycheckService>();

            var presenter = new CreateLaborContractPresenter(view.Object, service.Object);
            var e = new Mock<PaycheckEventArgs>(obj1, obj2, obj3);

            view.Setup(x => x.Model.EmployeePaycheck).Returns(new FakeEmployeePaycheck()).Verifiable();
        }
    }
}
