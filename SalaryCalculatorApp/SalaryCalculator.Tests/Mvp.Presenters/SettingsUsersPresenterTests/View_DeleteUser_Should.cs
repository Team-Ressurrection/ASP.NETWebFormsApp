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

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsUsersPresenterTests
{
    [TestFixture]
    public class View_DeleteUser_Should
    {
        [Test]
        public void InvokeOnce_WhenIsCalled()
        {
            var view = new Mock<ISettingsUsersView>();
            var userService = new Mock<IUserService>();

            var users = new List<FakeUser>()
            {
                new FakeUser() {Id=Guid.NewGuid().ToString() },
                new FakeUser() {Id=Guid.NewGuid().ToString() }
            };

            view.Setup(x => x.Model.Users).Returns(users).Verifiable();
            userService.Setup(x => x.DeleteById(users[0].Id)).Verifiable();

            var presenter = new SettingsUsersPresenter(view.Object, userService.Object);
            presenter.View_DeleteUser(new object { }, new ModelIdEventArgs(users[0].Id));

            userService.Verify(x => x.DeleteById(users[0].Id), Times.Once);
        }
    }
}
