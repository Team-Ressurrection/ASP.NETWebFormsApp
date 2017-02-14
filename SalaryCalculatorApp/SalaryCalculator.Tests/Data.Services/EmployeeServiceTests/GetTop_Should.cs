using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class GetTop_Should
    {
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
    }
}
