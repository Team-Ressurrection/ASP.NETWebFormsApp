using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.RemunerationBillTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void GetById_ShouldInvokeOnlyOnce()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            var mockedBill = new FakeRemunerationBill();
            mockedBill.Id = 2;
            billService.Create(mockedBill);

            billService.GetById(mockedBill.Id);
            mockedRepository.Verify(r => r.GetById(mockedBill.Id), Times.Once);
        }

    }
}
