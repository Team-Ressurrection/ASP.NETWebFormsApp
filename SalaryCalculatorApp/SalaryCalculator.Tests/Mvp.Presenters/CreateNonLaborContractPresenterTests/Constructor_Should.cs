using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateNonLaborContractPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var service = new Mock<IRemunerationBillService>();
            var calculate = new FakePayroll();

            Assert.IsInstanceOf<ICreateNonLaborContractPresenter>(new CreateNonLaborContractPresenter(view.Object, service.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenServiceParameterIsNull()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateNonLaborContractPresenter(view.Object, null, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenCalculateParameterIsNull()
        {
            var view = new Mock<ICreateNonLaborContractView>();
            var service = new Mock<IRemunerationBillService>();

            Assert.Throws<ArgumentNullException>(() => new CreateNonLaborContractPresenter(view.Object, service.Object, null));
        }
    }
}
