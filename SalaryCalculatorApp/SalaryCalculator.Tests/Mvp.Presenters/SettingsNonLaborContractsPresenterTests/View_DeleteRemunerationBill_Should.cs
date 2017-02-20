using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsNonLaborContractsPresenterTests
{
    [TestFixture]
    public class View_DeleteRemunerationBill_Should
    {
        [Test]
        public void CallRemunerationBillService_WhenMethodIsInvoked()
        {
            var view = new Mock<ISettingsNonLaborContractsView>();
            var service = new Mock<IRemunerationBillService>();

            var paychecks = new List<FakeRemunerationBill>()
            {
                new FakeRemunerationBill() {Id=1 },
                new FakeRemunerationBill() {Id=2 }
            };
            int id = 1;

            view.Setup(x => x.Model.NonLaborContracts).Returns(paychecks).Verifiable();
            service.Setup(x => x.DeleteById(id)).Verifiable();

            var presenter = new SettingsNonLaborContractsPresenter(view.Object, service.Object);
            presenter.View_DeleteRemunerationBill(new object { }, new ModelIdEventArgs(id));

            service.Verify(x => x.DeleteById(id), Times.Once);
        }
    }
}
