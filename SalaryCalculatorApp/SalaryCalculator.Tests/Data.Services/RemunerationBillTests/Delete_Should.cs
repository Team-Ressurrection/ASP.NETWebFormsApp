using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.RemunerationBillTests
{
    [TestFixture]
   public class Delete_Should
    {
        [Test]
        public void Delete_ShouldInvokeOnce_WhenValidId_IsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            RemunerationBill bill = new FakeRemunerationBill();
            bill.Id = 2;
            billService.Create(bill);
            billService.DeleteById(2);

            mockedRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
