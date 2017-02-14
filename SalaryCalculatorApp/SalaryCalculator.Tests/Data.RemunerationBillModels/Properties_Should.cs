using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Tests.Data.RemunerationBillModels
{
    [TestFixture]
    public class Properties_Should
    {
        private const string CreatedDateProperty = "CreatedDate";
        private const string IdProperty = "Id";
        private const string GrossSalaryProperty = "GrossSalary";
        private const string SocialSecurityIncomeProperty = "SocialSecurityIncome";
        private const string IncomeTaxProperty = "IncomeTax";
        private const string PersonalInsuranceProperty = "PersonalInsurance";
        private const string NetWageProperty = "NetWage";
        private const string EmployeeIdProperty = "EmployeeId";

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

        [Test]
        public void PropertyWithKeyAttribute_ShouldReturnTrue()
        {
            var bill = new RemunerationBill();

            var result = bill.GetType()
                             .GetProperty(IdProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(KeyAttribute))
                             .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void PropertyWithForeignKeyAttribute_ShouldReturnTrue()
        {
            var bill = new RemunerationBill();

            var result = bill.GetType()
                             .GetProperty("Employee")
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(ForeignKeyAttribute))
                             .Any();

            Assert.IsTrue(result);
        }

        [TestCase(SocialSecurityIncomeProperty)]
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
