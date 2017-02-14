using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.RemunerationBillTests
{
    [TestFixture]
    public class GetTop_Should
    {
        [Test]
        public void GetTop_ShouldInvokeOnlyOnce()
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

            billService.GetTop(3);
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void GetTop_ShouldReturnInstanceOfIQueryable()
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

            var query = billService.GetTop(3);
            Assert.IsInstanceOf<IQueryable<RemunerationBill>>(query);
        }
    }
}
