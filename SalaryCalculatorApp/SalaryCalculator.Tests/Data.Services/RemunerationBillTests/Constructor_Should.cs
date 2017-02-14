using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Services;

namespace SalaryCalculator.Tests.Data.Services.RemunerationBillTests
{
    [TestFixture]
    public class RemunerationBillServicesTests
    {
        [Test]
        public void Constructor_WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            Assert.IsInstanceOf(typeof(RemunerationBillService), billService);
        }
    }
}
