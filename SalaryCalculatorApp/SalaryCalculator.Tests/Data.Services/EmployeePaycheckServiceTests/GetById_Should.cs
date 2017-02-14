using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void GetById_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(mockedRepository.Object);

            var paycheck = new FakeEmployeePaycheck();
            paycheck.Id = 2;
            paycheckService.Create(paycheck);

            paycheckService.GetById(paycheck.Id);
            mockedRepository.Verify(r => r.GetById(paycheck.Id), Times.Once);
        }
    }
}
