using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsLaborContractsPresenterTests
{
    [TestFixture]
    public class GetAllLaborContracts_Should
    {
        [Test]
        public void GetAllLaborContracts_ShouldPassWithoutException_WhenIsInvoked()
        {
            var view = new Mock<ISettingsLaborContractsView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var eventArgs = new Mock<EventArgs>();
            var presenter = new SettingsLaborContractsPresenter(view.Object, paycheckService.Object);

            var contracts = new List<FakeEmployeePaycheck>() { new FakeEmployeePaycheck() };
            view.Setup(x => x.Model.LaborContracts).Returns(contracts).Verifiable();
            paycheckService.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            presenter.GetAllLaborContracts(new object { }, eventArgs.Object);

            paycheckService.Verify(x => x.GetAll(), Times.Once);
        }

    }
}
