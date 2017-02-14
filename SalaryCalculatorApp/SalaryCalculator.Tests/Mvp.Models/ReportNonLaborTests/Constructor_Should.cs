using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Models.ReportNonLaborTests
{
    [TestFixture]
    public class ReportNonLaborModelTests
    {
        [Test]
        public void WhenCreatingNewInstance_PropertySetterNonLaborContracts_ShouldReturnIEnumerable()
        {
            var model = new ReportNonLaborModel();
            var mockedBill = new FakeRemunerationBill();
            var collection = new List<FakeRemunerationBill>() { mockedBill };
            model.NonLaborContracts = collection;

            Assert.IsInstanceOf<IEnumerable<RemunerationBill>>(model.NonLaborContracts);
        }
    }
}
