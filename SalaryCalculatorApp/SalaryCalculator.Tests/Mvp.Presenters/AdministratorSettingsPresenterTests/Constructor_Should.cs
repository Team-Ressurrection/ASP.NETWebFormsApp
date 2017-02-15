using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Tests.Mvp.Presenters.AdministratorSettingsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<IAdministratorSettingsView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentservice = new Mock<ISelfEmploymentService>();

            Assert.IsInstanceOf<IAdministratorSettingsPresenter>(new AdministratorSettingsPresenter(view.Object,paycheckService.Object, billService.Object ,selfEmploymentservice.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenPaycheckServiceParameterIsNull()
        {
            var view = new Mock<IAdministratorSettingsView>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentservice = new Mock<ISelfEmploymentService>();

            Assert.Throws<ArgumentNullException>(() => new AdministratorSettingsPresenter(view.Object, null, billService.Object, selfEmploymentservice.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenRemunerationBillServiceIsNull()
        {
            var view = new Mock<IAdministratorSettingsView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var selfEmploymentservice = new Mock<ISelfEmploymentService>();

            Assert.Throws<ArgumentNullException>(() => new AdministratorSettingsPresenter(view.Object, paycheckService.Object, null, selfEmploymentservice.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenSelfEmploymentServiceParameterIsNull()
        {
            var view = new Mock<IAdministratorSettingsView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();

            Assert.Throws<ArgumentNullException>(() => new AdministratorSettingsPresenter(view.Object, paycheckService.Object, billService.Object, null));
        }
    }
}
