using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Services;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class EmployeeServicesTests
    {
        [Test]
        public void Constructor_WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            Assert.IsInstanceOf(typeof(EmployeeService), emplService);
        }
    }
}
