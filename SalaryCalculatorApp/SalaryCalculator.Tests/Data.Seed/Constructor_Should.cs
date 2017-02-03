using NUnit.Framework;
using SalaryCalculator.Data.Migrations;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
