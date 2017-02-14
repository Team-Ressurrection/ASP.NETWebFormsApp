using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class UserServicesTests
    {
        [Test]
        public void Constructor_WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            Assert.IsInstanceOf(typeof(UserService), userService);
        }
    }
}
