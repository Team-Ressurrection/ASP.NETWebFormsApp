using System;
using System.Linq;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services
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
