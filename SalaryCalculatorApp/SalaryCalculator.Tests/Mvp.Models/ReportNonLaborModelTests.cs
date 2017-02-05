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
