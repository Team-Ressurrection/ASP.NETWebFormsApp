using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class Create_Should
    {
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
    }
}
