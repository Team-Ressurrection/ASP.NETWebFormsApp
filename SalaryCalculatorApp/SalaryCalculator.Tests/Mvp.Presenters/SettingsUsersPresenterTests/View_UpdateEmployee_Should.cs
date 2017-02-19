using System;
using System.Web.ModelBinding;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

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
    }
}
