using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.RemunerationBillTests
{
    [TestFixture]
    public class UpdateById_Should
    {
        [Test]
        public void UpdateById_ShouldInvokeOnceAndUpdateBill()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            RemunerationBill mockedBill = new FakeRemunerationBill();
            RemunerationBill mockedBill2 = new FakeRemunerationBill();
            RemunerationBill mockedBill3 = new FakeRemunerationBill();
            mockedBill.Id = 2;
            mockedBill2.Id = 3;
            mockedBill3.Id = 4;

            billService.Create(mockedBill);
            billService.Create(mockedBill2);
            billService.Create(mockedBill3);

            billService.UpdateById(2, mockedBill);
            mockedRepository.Verify(r => r.Update(mockedBill), Times.Once);
        }
    }
}
