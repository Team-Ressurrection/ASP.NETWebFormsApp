using System.ComponentModel.DataAnnotations;
using System.Linq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Models.Constants;

namespace SalaryCalculator.Tests.Data.RemunerationBillModels
{
    public class RemunerationBillTests
    {
        private const string CreatedDateProperty = "CreatedDate";
        private const string GrossSalaryProperty = "GrossSalary";
        private const string SocialSecurityIncomeProperty = "SocialSecurityIncome";
        private const string IncomeTaxProperty = "IncomeTax";
        private const string PersonalInsuranceProperty = "PersonalInsurance";
        private const string NetWageProperty = "NetWage";
        private const string EmployeeIdProperty = "EmployeeId";


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

        [TestCase(CreatedDateProperty)]
        [TestCase(GrossSalaryProperty)]
        [TestCase(SocialSecurityIncomeProperty)]
        [TestCase(IncomeTaxProperty)]
        [TestCase(PersonalInsuranceProperty)]
        [TestCase(NetWageProperty)]
        [TestCase(EmployeeIdProperty)]
        public void PropertiesWithRequiredAttribute_ShouldReturnTrue(string propertyName)
        {
            var bill = new RemunerationBill();

            var result = bill.GetType()
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        public void SocialSecurityIncomeProperty_WithRangeAttribute_MustReturnMaxSocialSecurityIncomeValue(string propertyName)
        {
            var bill = new RemunerationBill();

            var result = bill.GetType()
                            .GetProperty(SocialSecurityIncomeProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                             .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.MaxSocialSecurityIncome, result.Maximum);
        }
    }
}
