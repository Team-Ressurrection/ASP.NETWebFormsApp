using NUnit.Framework;

using SalaryCalculator.Utilities.Calculations;


namespace SalaryCalculator.Tests.Utilities.Calculations.PayrollTests
{
    [TestFixture]
    public class GetPersonalInsurance_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenParametersArePassed()
        {
            var salary = 1000;

            var payroll = new Payroll();

            Assert.AreEqual(salary * 0.188, payroll.GetPersonalInsurance(salary));
        }
    }
}
