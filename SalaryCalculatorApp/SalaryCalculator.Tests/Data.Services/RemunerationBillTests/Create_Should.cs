using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.RemunerationBillTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Create_ShouldThrowArgumentNullException_WhenParameterIsNull()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            Assert.That(() => billService.Create(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            var mockedBill = new FakeRemunerationBill();

            billService.Create(mockedBill);

            mockedRepository.Verify(r => r.Add(It.IsAny<RemunerationBill>()), Times.Once);
        }

        [Test]
        public void Create_ShouldInvokeOnce_WhenParameterIsCorrect()
        {
            var mockedRepository = new Mock<IRepository<RemunerationBill>>();

            var billService = new RemunerationBillService(mockedRepository.Object);

            var mockedBill = new FakeRemunerationBill();

            billService.Create(mockedBill);

            mockedRepository.Verify(r => r.Add(mockedBill), Times.Once);

        }
    }
}
