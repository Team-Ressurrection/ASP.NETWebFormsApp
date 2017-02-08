using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.EmployeePaycheckModels
{
    [TestFixture]
    public class EmployeePaycheckTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.IsInstanceOf<EmployeePaycheck>(paycheckService);
        }
    }
}
