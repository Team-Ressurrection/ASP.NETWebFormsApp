using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Mvp.Models.Reports;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Models.ReportLaborModelTests
{
    [TestFixture]
    public class Properties_Should
    {
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
