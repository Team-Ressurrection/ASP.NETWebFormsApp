using System;
using System.Linq;

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

            Assert.That(() => emplService.Create(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
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

            Employee employee = new FakeEmployee();
            employee.Id = 2;
            emplService.Create(employee);
            emplService.DeleteById(2);

            mockedRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetAll_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            var employee = new FakeEmployee();
            employee.Id = 2;
            emplService.Create(employee);

            emplService.GetAll();
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            var employee = new FakeEmployee();
            employee.Id = 2;
            emplService.Create(employee);

            emplService.GetById(employee.Id);
            mockedRepository.Verify(r => r.GetById(employee.Id), Times.Once);
        }

        [Test]
        public void GetTop_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            Employee employee = new FakeEmployee();
            Employee employee2 = new FakeEmployee();
            Employee employee3 = new FakeEmployee();
            employee.Id = 2;
            employee2.Id = 3;
            employee3.Id = 4;

            emplService.Create(employee);
            emplService.Create(employee2);
            emplService.Create(employee3);

            emplService.GetTop(3);
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void GetTop_ShouldReturnInstanceOfIQueryable()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            Employee employee = new FakeEmployee();
            Employee employee2 = new FakeEmployee();
            Employee employee3 = new FakeEmployee();
            employee.Id = 2;
            employee2.Id = 3;
            employee3.Id = 4;

            emplService.Create(employee);
            emplService.Create(employee2);
            emplService.Create(employee3);

            var query = emplService.GetTop(3);
            Assert.IsInstanceOf<IQueryable<Employee>>(query);
        }

        [Test]
        public void Update_ShouldUpdateEmployeeCorrectly()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            Employee employee = new FakeEmployee();
            employee.Id = 2;

            emplService.Create(employee);

            emplService.UpdateById(2,employee);

            mockedRepository.Verify(x => x.Update(employee), Times.Once);
        }
    }
}
