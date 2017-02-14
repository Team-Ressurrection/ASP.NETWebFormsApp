using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.ProfilePresenterTests
{
    [TestFixture]
   public class UpdateUser_Should
    {
        [Test]
        public void UpdateUser_ShouldNotThrowException_WhenParametersArePassed()
        {
            var view = new Mock<IProfileView>();
            var service = new Mock<IUserService>();

            var presenter = new ProfilePresenter(view.Object, service.Object);
            var randomStringId = "11111111";
            var eventArgs = new Mock<EventArgs>();

            var user = new FakeUser();
            user.Id = "11111111";
            user.ImagePath = "default.png";
            view.Setup(x => x.Model.User).Returns(user as User);
            service.Setup(x => x.Create(user as User)).Verifiable();
            service.Setup(x => x.UpdateById(user.Id, user as User)).Verifiable();

            presenter.UpdateUser(randomStringId, eventArgs.Object);

            service.Verify(x => x.UpdateById(user.Id, user), Times.AtMostOnce);
        }
    }
}
