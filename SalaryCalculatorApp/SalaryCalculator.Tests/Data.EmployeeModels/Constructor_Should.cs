using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.EmployeeModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfEmployeeCorrectly()
        {
            var employee = new Employee();

            Assert.IsInstanceOf(typeof(Employee), employee);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldSetPropertyRemunerationBillsAsEmptyHashSet()
        {
            var employee = new Employee();

            Assert.AreEqual(new HashSet<RemunerationBill>(), employee.RemunerationBills);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_IdProperty()
        {
            var empl = new Employee();

            Assert.AreEqual(0, empl.Id);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_FirstNameProperty()
        {
            var empl = new Employee();

            Assert.AreEqual(null, empl.FirstName);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_MiddleNameProperty()
        {
            var empl = new Employee();

            Assert.AreEqual(null, empl.MiddleName);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_LastNameProperty()
        {
            var empl = new Employee();

            Assert.AreEqual(null, empl.LastName);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_PersonalIdProperty()
        {
            var empl = new Employee();

            Assert.AreEqual(null, empl.PersonalId);
        }
    }
}
