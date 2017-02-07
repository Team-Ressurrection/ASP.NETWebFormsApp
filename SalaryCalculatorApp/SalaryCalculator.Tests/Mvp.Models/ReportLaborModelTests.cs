using NUnit.Framework;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
