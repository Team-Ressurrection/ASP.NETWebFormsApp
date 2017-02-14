using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Tests.Mvp.Presenter.ProfilePresenterTests
{
    [TestFixture]
    public class Constructor_Should
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
    }
}
