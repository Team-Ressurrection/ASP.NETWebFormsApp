using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsUsersPresenterTests
{
    [TestFixture]
    public class GetAllUsers_Should
    {
        [Test]
        public void InvokeOnce_WhenIsCalled()
        {
            var view = new Mock<ISettingsUsersView>();
            var userService = new Mock<IUserService>();
            var eventArgs = new Mock<EventArgs>();

            var users = new List<FakeUser>() { new FakeUser() { Id = Guid.NewGuid().ToString()} };
            view.Setup(x => x.Model.Users).Returns(users).Verifiable();
            userService.Setup(x => x.GetAll()).Returns(users.AsQueryable).Verifiable();

            var presenter = new SettingsUsersPresenter(view.Object, userService.Object);

            presenter.View_GetAllUsers(new object { }, eventArgs.Object);

            userService.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
