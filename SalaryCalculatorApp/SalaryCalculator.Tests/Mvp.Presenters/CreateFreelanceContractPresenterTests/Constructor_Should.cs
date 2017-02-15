using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateFreelanceContractPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var service = new Mock<ISelfEmploymentService>();
            var calculate = new FakePayroll();

            Assert.IsInstanceOf<ICreateFreelanceContractPresenter>(new CreateFreelanceContractPresenter(view.Object, service.Object, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenServiceParameterIsNull()
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateFreelanceContractPresenter(view.Object, null, calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenCalculateParameterIsNull()
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var service = new Mock<ISelfEmploymentService>();

            Assert.Throws<ArgumentNullException>(() => new CreateFreelanceContractPresenter(view.Object, service.Object, null));
        }
    }
}
