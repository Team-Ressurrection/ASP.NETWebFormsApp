using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsFreelanceContractsPresenterTests
{
    [TestFixture]
    public class View_DeleteSelfEmployment_Should
    {
        [Test]
        public void CallSelfEmploymentService_WhenMethodIsInvoked()
        {
            var view = new Mock<ISettingsFreelanceContractsView>();
            var service = new Mock<ISelfEmploymentService>();

            var paychecks = new List<FakeSelfEmployment>()
            {
                new FakeSelfEmployment() {Id=1 },
                new FakeSelfEmployment() {Id=2 }
            };
            int id = 1;

            view.Setup(x => x.Model.FreelanceContracts).Returns(paychecks).Verifiable();
            service.Setup(x => x.DeleteById(id)).Verifiable();

            var presenter = new SettingsFreelanceContractsPresenter(view.Object, service.Object);
            presenter.View_DeleteSelfEmployment(new object { }, new ModelIdEventArgs(id));

            service.Verify(x => x.DeleteById(id), Times.Once);
        }
    }
}
