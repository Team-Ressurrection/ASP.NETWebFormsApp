using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters
{
    [TestFixture]
    public class ProfilePresenterTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenParametersArePassedCorrectly()
        {
            var view = new Mock<IProfileView>();
            var service = new Mock<IUserService>();

            Assert.IsInstanceOf<IProfilePresenter>(new ProfilePresenter(view.Object, service.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParametersAreNullable()
        {
            var view = new Mock<IProfileView>();

            Assert.That(() => new ProfilePresenter(view.Object, null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void GetUser_ShouldNotThrowException_WhenParametersArePassed()
        {
            var view = new Mock<IProfileView>();
            var service = new Mock<IUserService>();

            var presenter = new ProfilePresenter(view.Object, service.Object);
            var randomStringId = "11111111";
            var eventArgs = new Mock<EventArgs>();

            var user = new FakeUser();
            user.Id = "11111111";
            view.Setup(x => x.Model.User).Returns(user as User);
            service.Setup(x => x.GetById(user.Id));
            presenter.GetUser(randomStringId, eventArgs.Object);

            service.Verify(x => x.GetById(user.Id), Times.Once);
        }

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
