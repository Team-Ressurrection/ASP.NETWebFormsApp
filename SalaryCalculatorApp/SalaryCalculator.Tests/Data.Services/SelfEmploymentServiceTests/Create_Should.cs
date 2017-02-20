using System;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.SelfEmploymentServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenParameterIsNull()
        {
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            Assert.That(() => selfEmplService.Create(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void InvokeOnce_WhenParameterIsPassedCorrectly()
        {
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            var mockedSelfEmployment = new FakeSelfEmployment();

            selfEmplService.Create(mockedSelfEmployment);

            mockedRepository.Verify(r => r.Add(It.IsAny<SelfEmployment>()), Times.Once);
        }

        [Test]
        public void InvokeOnce_WhenParameterIsCorrect()
        {
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            var mockedSelfEmployment = new FakeSelfEmployment();

            selfEmplService.Create(mockedSelfEmployment);

            mockedRepository.Verify(r => r.Add(mockedSelfEmployment), Times.Once);

        }
    }
}
