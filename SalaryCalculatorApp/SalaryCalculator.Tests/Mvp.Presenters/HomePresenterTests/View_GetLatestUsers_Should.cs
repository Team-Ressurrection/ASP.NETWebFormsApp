using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Home;
using SalaryCalculator.Mvp.Views.Home;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters.HomePresenterTests
{
    [TestFixture]
    public class View_GetLatestUsers_Should
    {
        [Test]
        public void InvokeOnce_WhenIsCalled()
        {
            var view = new Mock<IHomeView>();
            var userService = new Mock<IUserService>();
            var eventArgs = new Mock<EventArgs>();

            var users = new List<FakeUser>() { new FakeUser() { Id = Guid.NewGuid().ToString() } };
            view.Setup(x => x.Model.Users).Returns(users).Verifiable();
            userService.Setup(x => x.GetAll()).Returns(users.AsQueryable).Verifiable();

            var presenter = new HomePresenter(view.Object, userService.Object);

            view.Raise(x => x.GetLatestUsers += null, new EventArgs());

            userService.Verify(x => x.GetTop(3), Times.Once);
        }
    }
}
