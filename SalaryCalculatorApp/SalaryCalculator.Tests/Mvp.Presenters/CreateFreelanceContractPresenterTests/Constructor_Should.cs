using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Factories;

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
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.IsInstanceOf<ICreateFreelanceContractPresenter>(new CreateFreelanceContractPresenter(view.Object, service.Object, modelFactory.Object,calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenServiceParameterIsNull()
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            Assert.Throws<ArgumentNullException>(() => new CreateFreelanceContractPresenter(view.Object, null, modelFactory.Object,calculate));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenCalculateParameterIsNull()
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var service = new Mock<ISelfEmploymentService>();

            Assert.Throws<ArgumentNullException>(() => new CreateFreelanceContractPresenter(view.Object, service.Object, modelFactory.Object,null));
        }
    }
}
