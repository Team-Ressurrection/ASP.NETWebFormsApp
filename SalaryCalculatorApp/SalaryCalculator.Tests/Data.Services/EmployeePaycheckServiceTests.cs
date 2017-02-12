using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Linq;

namespace SalaryCalculator.Tests.Data.Services
{
    [TestFixture]
    public class EmployeePaycheckServiceTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenParameterIRepositoryIsPassedCorrectly()
        {
            var repo = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(repo.Object);

            Assert.IsInstanceOf<IEmployeePaycheckService>(paycheckService);
        }

        [Test]
        public void Create_ShouldThrowArgumentNullException_WhenParameterIsNull()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            Assert.That(() => paycheckService.Create(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var paycheck = new FakeEmployeePaycheck();

            paycheckService.Create(paycheck);

            mockedRepository.Verify(r => r.Add(It.IsAny<EmployeePaycheck>()), Times.Once);
        }

        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsCorrect()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var paycheck = new FakeEmployeePaycheck();

            paycheckService.Create(paycheck);

            mockedRepository.Verify(r => r.Add(paycheck), Times.Once);

        }

        [Test]
        public void Delete_ShouldInvokeOnce_WhenValidId_IsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            EmployeePaycheck employee = new FakeEmployeePaycheck();
            employee.Id = 2;
            paycheckService.Create(employee);
            paycheckService.DeleteById(2);

            mockedRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetAll_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var employee = new FakeEmployeePaycheck();
            employee.Id = 2;
            paycheckService.Create(employee);

            paycheckService.GetAll();
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var paycheck = new FakeEmployeePaycheck();
            paycheck.Id = 2;
            paycheckService.Create(paycheck);

            paycheckService.GetById(paycheck.Id);
            mockedRepository.Verify(r => r.GetById(paycheck.Id), Times.Once);
        }

        [Test]
        public void GetTop_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var employee = new FakeEmployeePaycheck() { Id = 1 };
            var employee2 = new FakeEmployeePaycheck() { Id = 2 };
            var employee3 = new FakeEmployeePaycheck() { Id = 3 };

            paycheckService.Create(employee);
            paycheckService.Create(employee2);
            paycheckService.Create(employee3);

            paycheckService.GetTop(3);
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void GetTop_ShouldReturnInstanceOfIQueryable()
        {

            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var employee = new FakeEmployeePaycheck() { Id = 5 };
            var employee2 = new FakeEmployeePaycheck() { Id = 6 };
            var employee3 = new FakeEmployeePaycheck() { Id = 7 };

            paycheckService.Create(employee);
            paycheckService.Create(employee2);
            paycheckService.Create(employee3);

            var query = paycheckService.GetTop(3);
            Assert.IsInstanceOf<IQueryable<EmployeePaycheck>>(query);
        }
    }
}
