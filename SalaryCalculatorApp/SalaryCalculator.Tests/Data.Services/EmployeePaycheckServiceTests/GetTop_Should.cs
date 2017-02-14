using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class GetTop_Should
    {
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
