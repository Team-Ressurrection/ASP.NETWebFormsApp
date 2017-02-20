using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.SelfEmploymentServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ShouldInvokeOnlyOnce_WhenIsCalled()
        {
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            var mockedSelfEmployment = new FakeSelfEmployment();
            mockedSelfEmployment.Id = 2;
            selfEmplService.Create(mockedSelfEmployment);

            selfEmplService.GetAll();
            mockedRepository.Verify(r => r.All, Times.Once);
        }
    }
}
