using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class Delete_Should
    {
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
    }
}
