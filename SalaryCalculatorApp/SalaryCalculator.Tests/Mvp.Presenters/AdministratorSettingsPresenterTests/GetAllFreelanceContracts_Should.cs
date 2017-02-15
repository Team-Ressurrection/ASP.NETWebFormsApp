using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.AdministratorSettingsPresenterTests
{
    [TestFixture]
    public class GetAllFreelanceContracts_Should
    {
        [Test]
        public void GetAllFreelanceContracts_ShouldPassWithoutException_WhenIsInvoked()
        {
            var view = new Mock<IAdministratorSettingsView>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentservice = new Mock<ISelfEmploymentService>();
            var eventArgs = new Mock<EventArgs>();
            var presenter = new AdministratorSettingsPresenter(view.Object, paycheckService.Object, billService.Object, selfEmploymentservice.Object);

            var contracts = new List<FakeSelfEmployment>() { new FakeSelfEmployment() };
            view.Setup(x => x.Model.FreelanceContracts).Returns(contracts).Verifiable();
            selfEmploymentservice.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            presenter.GetAllFrelanceContracts(new object { }, eventArgs.Object);

            selfEmploymentservice.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
