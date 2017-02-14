using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using SalaryCalculator.Data.Migrations;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.Seed
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorShouldCreateInstanceCorrectly_WhenIsInvoked()
        {
            var seedData = new SeedData();

            Assert.IsInstanceOf<SeedData>(seedData);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertyEmployees()
        {
            var sd = new SeedData();

            Assert.IsInstanceOf<IEnumerable<Employee>>(sd.Employees);
        }


        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertyEmployeesWith15Elements()
        {
            var sd = new SeedData();

            Assert.AreEqual(15, sd.Employees.Count());
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertyRemunerationBills()
        {
            var sd = new SeedData();

            Assert.IsInstanceOf<IEnumerable<RemunerationBill>>(sd.RemunerationBills);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertyRemunerationBillsWith30Elements()
        {
            var sd = new SeedData();

            Assert.AreEqual(30, sd.RemunerationBills.Count());
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertyEmployeePaychecks()
        {
            var sd = new SeedData();

            Assert.IsInstanceOf<IEnumerable<EmployeePaycheck>>(sd.EmployeePaychecks);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertyEmployeePaychecksWith26Elements()
        {
            var sd = new SeedData();

            Assert.AreEqual(26, sd.EmployeePaychecks.Count());
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertySelfEmployment()
        {
            var sd = new SeedData();

            Assert.IsInstanceOf<IEnumerable<SelfEmployment>>(sd.SelfEmployments);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertySelfEmploymentsWith30Elements()
        {
            var sd = new SeedData();

            Assert.AreEqual(30, sd.SelfEmployments.Count());
        }
    }
}
