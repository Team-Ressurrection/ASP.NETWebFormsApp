using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class Delete_Should
    {
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
    }
}
