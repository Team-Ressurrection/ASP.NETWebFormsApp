using System;
using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services
{
    [TestFixture]
    public class EmployeeServicesTests
    {
        [Test]
        public void Constructor_WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            Assert.IsInstanceOf(typeof(EmployeeService), emplService);
        }

        [Test]
        public void Create_ShouldThrowArgumentNullException_WhenParameterIsNull()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            Assert.That(() => emplService.Create(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Employee cannot be null"));
        }

        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            var employee = new FakeEmployee();

            emplService.Create(employee);

            mockedRepository.Verify(r => r.Add(It.IsAny<Employee>()), Times.Once);
        }

        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsCorrect()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            var employee = new FakeEmployee();

            emplService.Create(employee);

            mockedRepository.Verify(r => r.Add(employee), Times.Once);

        }

        [Test]
        public void Delete_ShouldInvokeOnce_WhenValidId_IsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            var employee = new FakeEmployee();
            employee.Id = 2;
            emplService.Create(employee);
            emplService.DeleteById(2);

            mockedRepository.Verify(r => r.Delete(It.IsAny<Employee>()), Times.Once);
        }

        [Test]
        public void GetAll_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            var employee = new FakeEmployee();
            employee.Id = 2;
            emplService.Create(employee);

            mockedRepository.Verify(r => r.GetAll(), Times.Once);
        }
    }
}
