using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsLaborContractsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ISettingsLaborContractsView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();

            Assert.IsInstanceOf<ISettingsLaborContractsPresenter>(new SettingsLaborContractsPresenter(view.Object, paycheckService.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenSelfEmploymentServiceParameterIsNull()
        {
            var view = new Mock<ISettingsLaborContractsView>();

            Assert.Throws<ArgumentNullException>(() => new SettingsLaborContractsPresenter(view.Object,null));
        }
    }
}
