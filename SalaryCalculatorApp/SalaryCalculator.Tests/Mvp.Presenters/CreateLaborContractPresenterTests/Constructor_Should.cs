using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
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
            var service = new Mock<IEmployeePaycheckService>();
            var calculate = new FakeCalculate();

            Assert.IsInstanceOf<ICreateLaborContractPresenter>(new CreateLaborContractPresenter(view.Object, service.Object,calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenServiceParameterIsNull()
        {
            var view = new Mock<ICreateLaborContractView>();
            var calculate = new FakeCalculate();

            Assert.Throws<ArgumentNullException>(() => new CreateLaborContractPresenter(view.Object, null, calculate));
        }
    }
}
