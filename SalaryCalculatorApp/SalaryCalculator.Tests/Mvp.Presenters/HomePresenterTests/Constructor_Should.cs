using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Home;
using SalaryCalculator.Mvp.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters.HomePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<IHomeView>();
            var userService = new Mock<IUserService>();

            var presenter = new HomePresenter(view.Object, userService.Object);

            Assert.IsInstanceOf<IHomePresenter>(presenter);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceParametersIsNull()
        {
            var view = new Mock<IHomeView>();

            Assert.Throws<ArgumentNullException>(() => new HomePresenter(view.Object, null));
        }
    }
}
