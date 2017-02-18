using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsFreelanceContractsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ISettingsFreelanceContractsView>();
            var selfEmploymentservice = new Mock<ISelfEmploymentService>();

            Assert.IsInstanceOf<ISettingsFreelanceContractsPresenter>(new SettingsFreelanceContractsPresenter(view.Object,selfEmploymentservice.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenSelfEmploymentServiceParameterIsNull()
        {
            var view = new Mock<ISettingsFreelanceContractsView>();

            Assert.Throws<ArgumentNullException>(() => new SettingsFreelanceContractsPresenter(view.Object,null));
        }
    }
}
