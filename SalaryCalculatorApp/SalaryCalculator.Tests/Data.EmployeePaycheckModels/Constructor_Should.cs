using System;
using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.EmployeePaycheckModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfEmployeePaycheckCorrectly()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.IsInstanceOf(typeof(EmployeePaycheck), paycheckService);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldSetPropertyRemunerationBillsAsEmptyHashSet()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.IsAssignableFrom(typeof(DateTime), paycheckService.CreatedDate);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IdProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0, paycheckService.Id);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_EmployeeIdProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0, paycheckService.EmployeeId);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossFixedBonusProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0m, paycheckService.GrossFixedBonus);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossNonFixedBonusProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0m, paycheckService.GrossNonFixedBonus);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossSalaryProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0m, paycheckService.GrossSalary);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IncomeTaxProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0m, paycheckService.IncomeTax);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_NetWageProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0m, paycheckService.NetWage);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_PersonalInsuranceProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0m, paycheckService.PersonalInsurance);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_SocialSecurityIncomeProperty()
        {
            var paycheckService = new EmployeePaycheck();

            Assert.AreEqual(0m, paycheckService.SocialSecurityIncome);
        }
    }
}
