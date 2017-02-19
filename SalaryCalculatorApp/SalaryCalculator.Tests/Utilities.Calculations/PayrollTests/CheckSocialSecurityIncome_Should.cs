using NUnit.Framework;

using SalaryCalculator.Utilities.Calculations;


namespace SalaryCalculator.Tests.Utilities.Calculations.PayrollTests
{
    [TestFixture]
    public class CheckSocialSecurityIncome_Should
    {
        [TestCase(2600)]
        [TestCase(2601)]
        public void ReturnTrue_IfValueIsEqualTo2600(decimal salary)
        {
            var payroll = new Payroll();

            var result = payroll.CheckMaxSocialSecurityIncome(salary);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnTrue_IfValueIsLessThan2600()
        {
            var salary = 2599;

            var payroll = new Payroll();

            var result = payroll.CheckMaxSocialSecurityIncome(salary);

            Assert.IsFalse(result);
        }
    }
}
