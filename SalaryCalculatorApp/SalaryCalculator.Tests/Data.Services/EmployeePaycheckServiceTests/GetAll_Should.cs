using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAll_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var employee = new FakeEmployeePaycheck();
            employee.Id = 2;
            paycheckService.Create(employee);

            paycheckService.GetAll();
            mockedRepository.Verify(r => r.All, Times.Once);
        }
    }
}
