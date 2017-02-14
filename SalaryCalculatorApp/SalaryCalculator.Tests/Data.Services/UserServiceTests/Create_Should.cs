using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            var user = new FakeUser();

            userService.Create(user);

            mockedRepository.Verify(r => r.Add(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsCorrect()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            var user = new FakeUser();

            userService.Create(user);

            mockedRepository.Verify(r => r.Add(user), Times.Once);
        }
    }
}
