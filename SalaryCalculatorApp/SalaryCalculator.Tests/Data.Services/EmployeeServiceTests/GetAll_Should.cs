using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
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
    }
}
