using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenParameterIRepositoryIsPassedCorrectly()
        {
            var repo = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(repo.Object);

            Assert.IsInstanceOf<IEmployeePaycheckService>(paycheckService);
        }
    }
}
