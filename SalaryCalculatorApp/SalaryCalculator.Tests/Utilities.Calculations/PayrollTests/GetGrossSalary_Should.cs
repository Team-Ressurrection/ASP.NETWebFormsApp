using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

using SalaryCalculator.Utilities.Calculations;

namespace SalaryCalculator.Tests.Utilities.Calculations.PayrollTests
{
    [TestFixture]
    public class GetGrossSalary_Should
    {
        [Test]
        public void ReturnSumOfAllParameters()
        {
            var parameters = new List<decimal>() { 450, 500, 50 };

            var payroll = new Payroll();

            Assert.AreEqual(parameters.Sum(), payroll.GetGrossSalary(parameters));
        }
    }
}
