using NUnit.Framework;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.SelfEmploymentModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfSelfEmploymentCorrectly()
        {
            var selfEmpl = new SelfEmployment();

            Assert.IsInstanceOf(typeof(SelfEmployment), selfEmpl);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldSetPropertyRemunerationBillsAsEmptyHashSet()
        {
            var selfEmpl = new SelfEmployment();

            Assert.IsAssignableFrom(typeof(DateTime), selfEmpl.CreatedDate);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IdProperty()
        {
            var selfEmpl = new Employee();

            Assert.AreEqual(0, selfEmpl.Id);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_EmployeeIdProperty()
        {
            var selfEmpl = new SelfEmployment();

            Assert.AreEqual(0, selfEmpl.EmployeeId);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossSalaryProperty()
        {
            var selfEmpl = new SelfEmployment();

            Assert.AreEqual(0m, selfEmpl.GrossSalary);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IncomeTaxProperty()
        {
            var selfEmpl = new SelfEmployment();

            Assert.AreEqual(0m, selfEmpl.IncomeTax);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_NetWageProperty()
        {
            var selfEmpl = new SelfEmployment();

            Assert.AreEqual(0m, selfEmpl.NetWage);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_PersonalInsuranceProperty()
        {
            var selfEmpl = new SelfEmployment();

            Assert.AreEqual(0m, selfEmpl.PersonalInsurance);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_SocialSecurityIncomeProperty()
        {
            var selfEmpl = new SelfEmployment();

            Assert.AreEqual(0m, selfEmpl.SocialSecurityIncome);
        }
    }
}