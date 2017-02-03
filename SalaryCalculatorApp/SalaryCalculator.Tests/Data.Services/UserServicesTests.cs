using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.Services
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

        [Test]
        public void Delete_ShouldInvokeOnce_WhenValidId_IsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            User user = new FakeUser();
            user.Id = "lskdjaskldjlskajdklasjdlkasjdlkasjdlk";
            userService.Create(user);
            userService.DeleteById(1);

            mockedRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }

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
