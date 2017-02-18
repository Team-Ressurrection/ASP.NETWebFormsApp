using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsNonLaborContractsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ISettingsNonLaborContractsView>();
            var billService = new Mock<IRemunerationBillService>();

            Assert.IsInstanceOf<ISettingsNonLaborContractsPresenter>(new SettingsNonLaborContractsPresenter(view.Object,billService.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenRemunerationBillServiceParameterIsNull()
        {
            var view = new Mock<ISettingsNonLaborContractsView>();

            Assert.Throws<ArgumentNullException>(() => new SettingsNonLaborContractsPresenter(view.Object,null));
        }
    }
}
