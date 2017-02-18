using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Mvp.Models.Reports;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Models.ReportNonLaborTests
{
    [TestFixture]
    public class Properties_Should
    {
        [Test]
        public void WhenPropertyLaborContracts_IsSetProperly_ShouldReturnIEnumerable()
        {
            var model = new ReportNonLaborModel();
            var mockedBill = new FakeRemunerationBill();
            var collection = new List<FakeRemunerationBill>() { mockedBill };

            model.NonLaborContracts = collection;

            Assert.AreEqual(collection, model.NonLaborContracts);
        }
    }
}
