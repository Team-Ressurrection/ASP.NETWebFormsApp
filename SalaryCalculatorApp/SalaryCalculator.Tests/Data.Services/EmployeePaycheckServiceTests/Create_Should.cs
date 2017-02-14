using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class Create_Should
    {
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
    }
}
