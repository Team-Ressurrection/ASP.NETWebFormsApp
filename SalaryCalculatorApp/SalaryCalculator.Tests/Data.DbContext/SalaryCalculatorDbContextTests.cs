using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;
using NUnit.Framework;

using SalaryCalculator.Data;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.DbContext
{
    [TestFixture]
    public class SalaryCalculatorDbContextTests
    {
        [Test]
        public void ConstructorWhenPassed_ShouldCreateInstance()
        {
            var dbContext = new SalaryCalculatorDbContext();

            Assert.IsInstanceOf(typeof(IdentityDbContext<User>), dbContext);
        }

        [Test]
        public void DbContext_ShouldHave_DbSetPropertyEmployees()
        {
            ISalaryCalculatorDbContext dbContext = SalaryCalculatorDbContext.Create();

            var dbSetEmployees = dbContext.Set<FakeEmployee>();

            Assert.IsInstanceOf(typeof(DbSet<Employee>), dbSetEmployees);
        }
    }
}
