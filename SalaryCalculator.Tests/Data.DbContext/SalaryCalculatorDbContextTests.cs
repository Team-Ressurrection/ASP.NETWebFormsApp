using NUnit.Framework;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.DbContext
{
    [TestFixture]
    public class SalaryCalculatorDbContextTests
    {
        [Test]
        public void ConstructorWhenPassed_ShouldCreateInstance()
        {
            SalaryCalculatorDbContext dbContext = SalaryCalculatorDbContext.Create();

            Assert.IsInstanceOf<ISalaryCalculatorDbContext>(dbContext);
        }
    }
}
