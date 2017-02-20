using System.Linq;
using System.ComponentModel.DataAnnotations;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Tests.Data.EmployeeModels
{
    [TestFixture]
    public class Properties_Should
    {
        private const string FirstNameProperty = "FirstName";
        private const string MiddleNameProperty = "MiddleName";
        private const string LastNameProperty = "LastName";
        private const string PersonalIdProperty = "PersonalId";

        [Test]
        public void WhenPersonalIdIsSetWithCorrectValue_ShouldSet_PersonalIdProperty()
        {
            var empl = new Employee();

            empl.PersonalId = "8801124520";
            Assert.AreEqual("8801124520", empl.PersonalId);
        }

        [TestCase("Georgi Georgiev Vasilev")]
        [TestCase("Ivan Ivanov Ivanov")]
        [TestCase("Al Alf Alfa")]
        public void WhenParameterFirstName_IsSetWithValidValue_ShouldSetUpCorrectly(string name)
        {
            var names = name.Split(' ').ToArray();
            var empl = new Employee();

            empl.FirstName = names[0];
            empl.MiddleName = names[1];
            empl.LastName = names[2];

            Assert.AreEqual(names[0], empl.FirstName);
            Assert.AreEqual(names[1], empl.MiddleName);
            Assert.AreEqual(names[2], empl.LastName);
        }

        [Test]
        public void FirstNameProperty_ShouldSetCorrectly_MaxLengthAttribute()
        {
            var empl = new Employee();
            var result = empl.GetType()
                             .GetProperty(FirstNameProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                             .Select(x => (MaxLengthAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.MaximumNameLength, result.Length);
        }

        [Test]
        public void MiddleNameProperty_ShouldSetCorrectly_MaxLengthAttribute()
        {
            var empl = new Employee();

            var result = empl.GetType()
                             .GetProperty(MiddleNameProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                             .Select(x => (MaxLengthAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.MaximumNameLength, result.Length);
        }

        [Test]
        public void LastNameProperty_ShouldSetCorrectly_MaxLengthAttribute()
        {
            var empl = new Employee();

            var result = empl.GetType()
                             .GetProperty(MiddleNameProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                             .Select(x => (MaxLengthAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.MaximumNameLength, result.Length);
        }

        [Test]
        public void FirstNameProperty_ShouldSetCorrectly_MinLengthAttribute()
        {
            var empl = new Employee();
            var result = empl.GetType()
                             .GetProperty(FirstNameProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(MinLengthAttribute))
                             .Select(x => (MinLengthAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.MinimumNameLength, result.Length);
        }

        [Test]
        public void MiddleNameProperty_ShouldSetCorrectly_MinLengthAttribute()
        {
            var empl = new Employee();

            var result = empl.GetType()
                             .GetProperty(MiddleNameProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(MinLengthAttribute))
                             .Select(x => (MinLengthAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.MinimumNameLength, result.Length);
        }

        [Test]
        public void LastNameProperty_ShouldSetCorrectly_MinLengthAttribute()
        {
            var empl = new Employee();

            var result = empl.GetType()
                             .GetProperty(LastNameProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(MinLengthAttribute))
                             .Select(x => (MinLengthAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.MinimumNameLength, result.Length);
        }

        [Test]
        public void PersonalIdProperty_ShouldSetCorrectly_StringLengthAttribute()
        {
            var empl = new Employee();

            var result = empl.GetType()
                             .GetProperty(PersonalIdProperty)
                             .GetCustomAttributes(false)
                             .Where(x => x.GetType() == typeof(StringLengthAttribute))
                             .Select(x => (StringLengthAttribute)x)
                             .FirstOrDefault();

            Assert.AreEqual(ValidationConstants.PersonalIdLength, result.MaximumLength);
        }

        [TestCase(FirstNameProperty)]
        [TestCase(MiddleNameProperty)]
        [TestCase(LastNameProperty)]
        [TestCase(PersonalIdProperty)]
        public void PropertiesWithRequiredAttribute_ShouldReturnTrue(string propertyName)
        {
            var empl = new Employee();

            var result = empl.GetType()
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void PropertyRemunerationBIll_ShouldSetCorrectly_ValueOfIDBill()
        {
            var empl = new Employee();

            empl.RemunerationBills.Add(new FakeRemunerationBill());

            Assert.AreEqual(empl.RemunerationBills.Count, 1);
        }

        [Test]
        public void PropertyEmployeePaycheck_ShouldSetCorrectly_ValueOfIDPaycheck()
        {
            var empl = new Employee();

            empl.EmployeePaychecks.Add(new FakeEmployeePaycheck());

            Assert.AreEqual(empl.EmployeePaychecks.Count, 1);
        }

        [Test]
        public void PropertySelfEmployment_ShouldSetCorrectly_ValueOfIDSelfEmployment()
        {
            var empl = new Employee();

            empl.SelfEmployments.Add(new FakeSelfEmployment());

            Assert.AreEqual(empl.SelfEmployments.Count, 1);
        }
    }
}
