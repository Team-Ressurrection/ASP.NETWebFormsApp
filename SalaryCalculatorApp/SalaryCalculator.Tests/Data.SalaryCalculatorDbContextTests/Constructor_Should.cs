using Microsoft.AspNet.Identity.EntityFramework;

using NUnit.Framework;

using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.SalaryCalculatorDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorWhenPassed_ShouldCreateInstance()
        {
            var dbContext = new SalaryCalculatorDbContext();

            Assert.IsInstanceOf(typeof(IdentityDbContext<User>), dbContext);
        }
    }
}
