using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Models
{
    [TestFixture]
    public class ReportLaborModelTests
    {
        [Test]
        public void WhenCreatingNewInstance_PropertySetterLaborContracts_ShouldReturnIEnumerable()
        {
            var model = new ReportLaborModel();
            var mockedPaycheck = new FakeEmployeePaycheck();
            var collection = new List<FakeEmployeePaycheck>() { mockedPaycheck };
            model.LaborContracts = collection;

            Assert.IsInstanceOf<IEnumerable<FakeEmployeePaycheck>>(model.LaborContracts);
        }

        [Test]
        public void WhenPropertyLaborContracts_IsSetProperly_ShouldReturnIEnumerable()
        {
            var model = new ReportLaborModel();
            var mockedPaycheck = new FakeEmployeePaycheck();
            var collection = new List<FakeEmployeePaycheck>() { mockedPaycheck };
            model.LaborContracts = collection;

            Assert.AreEqual(collection, model.LaborContracts);
        }
    }
}
