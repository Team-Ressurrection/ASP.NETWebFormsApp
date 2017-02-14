using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Update_ShouldUpdateEmployeeCorrectly()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            Employee employee = new FakeEmployee();
            employee.Id = 2;

            emplService.Create(employee);

            emplService.UpdateById(2, employee);

            mockedRepository.Verify(x => x.Update(employee), Times.Once);
        }
    }
}
