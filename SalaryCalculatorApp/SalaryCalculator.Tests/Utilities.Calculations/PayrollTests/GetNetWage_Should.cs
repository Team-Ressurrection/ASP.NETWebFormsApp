using NUnit.Framework;

using SalaryCalculator.Utilities.Calculations;


namespace SalaryCalculator.Tests.Utilities.Calculations.PayrollTests
{
    [TestFixture]
    public class GetNetWage_Should
    {
        [TestCase(1000, 150, 90)]
        public void ReturnCorrectNetWage_WhenParametersArePassedCorrectly(decimal num1, decimal num2, decimal num3)
        {
            var payroll = new Payroll();

            Assert.AreEqual(760m, payroll.GetNetWage(num1, num2, num3));
        }
    }
}
