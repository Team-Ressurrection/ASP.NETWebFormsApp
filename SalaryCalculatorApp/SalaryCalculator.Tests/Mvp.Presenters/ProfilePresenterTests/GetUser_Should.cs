using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Account;
using SalaryCalculator.Mvp.Views.Account;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Tests.Mvp.Presenters.ProfilePresenterTests
{
    [TestFixture]
    public class GetUser_Should
    {
        [Test]
        public void GetUser_ShouldNotThrowException_WhenParametersArePassed()
        {
            var view = new Mock<IProfileView>();
            var service = new Mock<IUserService>();

            var eventArgs = new Mock<IModelIdEventArgs>();

            var user = new FakeUser();
            user.Id = Guid.NewGuid().ToString();
            view.Setup(x => x.Model.User).Returns(user as User);
            service.Setup(x => x.GetById(user.Id));
            eventArgs.Setup(x => x.UserId).Returns(user.Id);
            var presenter = new ProfilePresenter(view.Object, service.Object);

            presenter.GetUser(user.Id, eventArgs.Object);

            service.Verify(x => x.GetById(user.Id), Times.Once);
        }
    }
}
