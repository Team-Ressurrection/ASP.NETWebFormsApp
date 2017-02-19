using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsUsersPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ISettingsUsersView>();
            var userService = new Mock<IUserService>();

            var presenter = new SettingsUsersPresenter(view.Object, userService.Object);

            Assert.IsInstanceOf<ISettingsUsersPresenter>(presenter);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceParametersIsNull()
        {
            var view = new Mock<ISettingsUsersView>();

            Assert.Throws<ArgumentNullException>(()=> new SettingsUsersPresenter(view.Object, null));
        }
    }
}
