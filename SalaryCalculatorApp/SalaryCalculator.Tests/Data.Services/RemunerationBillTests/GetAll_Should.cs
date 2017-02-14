using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.RemunerationBillTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAll_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            var mockedBill = new FakeRemunerationBill();
            mockedBill.Id = 2;
            billService.Create(mockedBill);

            billService.GetAll();
            mockedRepository.Verify(r => r.All, Times.Once);
        }
    }
}
