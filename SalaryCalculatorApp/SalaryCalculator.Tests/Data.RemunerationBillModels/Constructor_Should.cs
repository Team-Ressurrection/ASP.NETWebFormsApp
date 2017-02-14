using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.RemunerationBillModels
{
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfRemunerationBillCorrectly()
        {
            var bill = new RemunerationBill();

            Assert.IsInstanceOf(typeof(RemunerationBill), bill);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_IdProperty()
        {
            var bill = new RemunerationBill();

            Assert.AreEqual(0, bill.Id);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_PersonalInsuranceProperty()
        {
            var bill = new RemunerationBill();

            Assert.AreEqual(0.0m, bill.PersonalInsurance);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_NetWageProperty()
        {
            var bill = new RemunerationBill();

            Assert.AreEqual(0.0m, bill.NetWage);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_IncomeTaxProperty()
        {
            var bill = new RemunerationBill();

            Assert.AreEqual(0.0m, bill.IncomeTax);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_GrossSalaryProperty()
        {
            var bill = new RemunerationBill();

            Assert.AreEqual(0.0m, bill.GrossSalary);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_SocialSecurityIncomeProperty()
        {
            var bill = new RemunerationBill();

            Assert.AreEqual(0.0m, bill.SocialSecurityIncome);
        }

       
    }
}
