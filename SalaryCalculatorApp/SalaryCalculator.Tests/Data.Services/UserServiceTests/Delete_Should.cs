using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;
using System;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void Delete_ShouldInvokeOnce_WhenValidId_IsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            User user = new FakeUser();
            user.Id = Guid.NewGuid().ToString();
            userService.Create(user);
            userService.DeleteById(user.Id);

            mockedRepository.Verify(r => r.Delete(It.IsAny<string>()), Times.Once);
        }
    }
}
