using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAll_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            var user = new FakeUser();
            user.Id = "2";
            userService.Create(user);

            userService.GetAll();
            mockedRepository.Verify(r => r.All, Times.Once);
        }
    }
}
