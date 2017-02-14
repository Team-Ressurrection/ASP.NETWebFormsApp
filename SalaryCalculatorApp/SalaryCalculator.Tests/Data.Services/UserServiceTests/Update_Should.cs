using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Update_ShouldUpdateUserCorrectly()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            User user = new FakeUser();
            user.Id = "1234567890";

            userService.Create(user);

            userService.UpdateById("1234567890", user);

            mockedRepository.Verify(x => x.Update(user), Times.Once);
        }
    }
}
