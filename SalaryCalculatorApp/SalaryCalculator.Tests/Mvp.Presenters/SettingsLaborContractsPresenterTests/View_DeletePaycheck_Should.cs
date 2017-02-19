using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsLaborContractsPresenterTests
{
    [TestFixture]
    public class View_DeletePaycheck_Should
    {
        [Test]
        public void CallPaycheckService_WhenMethodIsInvoked()
        {
            var view = new Mock<ISettingsLaborContractsView>();
            var service = new Mock<IEmployeePaycheckService>();

            var paychecks = new List<FakeEmployeePaycheck>()
            {
                new FakeEmployeePaycheck() {Id=1 },
                new FakeEmployeePaycheck() {Id=2 }
            };
            int id = 1;

            view.Setup(x => x.Model.LaborContracts).Returns(paychecks).Verifiable();
            service.Setup(x => x.DeleteById(id)).Verifiable();

            var presenter = new SettingsLaborContractsPresenter(view.Object, service.Object);
            presenter.View_DeletePaycheck(new object { }, new ModelIdEventArgs(id));

            service.Verify(x => x.DeleteById(id), Times.Once);
        }
    }
}
