using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class GetTop_Should
    {
        [Test]
        public void GetTop_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            User employee = new FakeUser();
            User employee2 = new FakeUser();
            User employee3 = new FakeUser();
            employee.Id = "2";
            employee2.Id = "3";
            employee3.Id = "4";

            userService.Create(employee);
            userService.Create(employee2);
            userService.Create(employee3);

            userService.GetTop(3);
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void GetTop_ShouldReturnInstanceOfIQueryable()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            User user = new FakeUser();
            User user2 = new FakeUser();
            User user3 = new FakeUser();
            user.Id = "2";
            user2.Id = "3";
            user3.Id = "4";

            userService.Create(user);
            userService.Create(user2);
            userService.Create(user3);

            var query = userService.GetTop(3);
            Assert.IsInstanceOf<IQueryable<User>>(query);
        }
    }
}
