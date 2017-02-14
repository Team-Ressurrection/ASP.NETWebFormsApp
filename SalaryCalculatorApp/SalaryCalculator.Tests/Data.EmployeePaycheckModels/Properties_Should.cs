using System.ComponentModel.DataAnnotations;
using System.Linq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.EmployeePaycheckModels
{
    [TestFixture]
    public class Properties_Should
    {
        private const string CreatedDateProperty = "CreatedDate";
        private const string GrossSalaryProperty = "GrossSalary";
        private const string GrossFixedBonusProperty = "GrossFixedBonus";
        private const string GrossNonFixedBonusProperty = "GrossNonFixedBonus";
        private const string SocialSecurityIncomeProperty = "SocialSecurityIncome";
        private const string PersonalInsuranceProperty = "PersonalInsurance";
        private const string IncomeTaxProperty = "IncomeTax";
        private const string NetWageProperty = "NetWage";
        private const string EmployeeIdProperty = "EmployeeId";

        [TestCase(1000, 200, 300)]
        [TestCase(500, 400, 300)]
        [TestCase(0, 0, 0)]
        public void WhenParameterFirstName_IsSetWithValidValue_ShouldSetUpCorrectly(decimal num1, decimal num2, decimal num3)
        {
            var paycheck = new EmployeePaycheck();

            paycheck.GrossSalary = num1;
            paycheck.GrossFixedBonus = num2;
            paycheck.GrossNonFixedBonus = num3;

            Assert.AreEqual(num1, paycheck.GrossSalary);
            Assert.AreEqual(num2, paycheck.GrossFixedBonus);
            Assert.AreEqual(num3, paycheck.GrossNonFixedBonus);
        }

        [TestCase(CreatedDateProperty)]
        [TestCase(SocialSecurityIncomeProperty)]
        [TestCase(PersonalInsuranceProperty)]
        [TestCase(IncomeTaxProperty)]
        [TestCase(GrossSalaryProperty)]
        [TestCase(NetWageProperty)]
        public void PropertiesWithRequiredAttribute_ShouldReturnTrue(string propertyName)
        {
            var paycheck = new EmployeePaycheck();

            var result = paycheck.GetType()
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
