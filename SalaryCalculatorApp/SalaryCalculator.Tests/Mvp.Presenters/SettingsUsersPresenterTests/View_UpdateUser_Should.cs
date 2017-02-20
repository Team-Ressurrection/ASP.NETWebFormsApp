using System;
using System.Web.ModelBinding;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsUsersPresenterTests
{
    [TestFixture]
    public class View_UpdateUser_Should
    {
        [Test]
        public void AddModelError_WhenUserIsNotFound()
        {
            var view = new Mock<ISettingsUsersView>();
            view.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            string userId = Guid.NewGuid().ToString();
            string expectedError = String.Format("User with id {0} was not found", userId);
            var userService = new Mock<IUserService>();
            userService.Setup(c => c.GetById(userId)).Returns<Employee>(null);

            ISettingsUsersPresenter presenter = new SettingsUsersPresenter
                (view.Object, userService.Object);

            view.Raise(v => v.UpdateModel += null, new ModelIdEventArgs(userId));

            Assert.AreEqual(1, view.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, view.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void TryUpdateModelIsNotCalled_WhenUserIsNotFound()
        {
            var view = new Mock<ISettingsUsersView>();
            view.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            string userId = Guid.NewGuid().ToString();
            var userService = new Mock<IUserService>();
            userService.Setup(c => c.GetById(userId)).Returns<User>(null);

            ISettingsUsersPresenter presenter = new SettingsUsersPresenter
                (view.Object, userService.Object);

            view.Raise(v => v.UpdateModel += null, new ModelIdEventArgs(userId));

            view.Verify(v => v.TryUpdateModel(It.IsAny<User>()), Times.Never());
        }

        [Test]
        public void UpdateByIdIsCalled_WhenUserIsFoundAndIsInValidState()
        {
            var view = new Mock<ISettingsUsersView>();
            view.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            string userId = Guid.NewGuid().ToString();
            var userService = new Mock<IUserService>();
            var user = new FakeUser() { Id = userId };
            userService.Setup(c => c.GetById(userId)).Returns(user);

            ISettingsUsersPresenter presenter = new SettingsUsersPresenter
                (view.Object, userService.Object);

            view.Raise(v => v.UpdateModel += null, new ModelIdEventArgs(userId));

            userService.Verify(c => c.UpdateById(userId,user), Times.Once());
        }
    }
}
