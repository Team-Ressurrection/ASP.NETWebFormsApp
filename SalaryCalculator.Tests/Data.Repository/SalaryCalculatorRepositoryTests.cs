using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Repositories;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.Repository
{
    [TestFixture]
    public class SalaryCalculatorRepositoryTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenDbContextParameterIsNull()
        {
            ISalaryCalculatorDbContext nullableDbContext = null;
            Assert.That(
                () => new SalaryCalculatorRepository<FakeEmployee>(nullableDbContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("SalaryCalculatorDbContext"));
        }

        [Test]
        public void Constructor_ShouldCreateInstanceCorrectly_WhenParameterIsSetCorrectly()
        {
            var mockedDbContext = new Mock<ISalaryCalculatorDbContext>();

            var repository = new SalaryCalculatorRepository<FakeEmployee>(mockedDbContext.Object);

            Assert.IsInstanceOf(typeof(IRepository<FakeEmployee>), repository);
        }

        [Test]
        public void AddMethod_ShouldInvokedOnce_WhenParameterIsPassedCorrectly()
        {
            var fakeDbSet = new Mock<DbSet<FakeEmployee>>();

            var fakeDbModel = new FakeEmployee();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(fakeDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            // Act
            repo.Add(fakeDbModel);

            // Assert
            mockDbContext.Verify(mock => mock.Entry(It.IsAny<FakeEmployee>()), Times.Once());

        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenFilterParameterIsNull()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            var fakeData = new List<FakeEmployee>()
            {
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<FakeEmployee, bool>> filter = null;
            Assert.That(
            () => repo.GetAll(filter),
            Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Filter expression"));
        }

        [Test]
        public void ShouldPassCorrectly_WhenFilterParameterIsValid()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            var fakeData = new List<FakeEmployee>()
            {
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
               new Mock<FakeEmployee>().Object,
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<FakeEmployee, bool>> filter = (FakeEmployee empl) => empl.FirstName.Equals("Alexander");

            var actualResult = repo.GetAll(filter);
            Assert.That(actualResult.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnTaskWithCorrectResult_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            // Setup Data
            var fakeMatchingModel = new Mock<FakeEmployee>();
            fakeMatchingModel.SetupGet(model => model.Id).Returns(1);

            var fakeData = new List<FakeEmployee>()
            {
                fakeMatchingModel.Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<FakeEmployee, bool>> filter = (FakeEmployee model) => model.Id == 1;

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter);

            var expectedCollection = new List<FakeEmployee>() { fakeMatchingModel.Object };

            Assert.That(actualReturnedCollection.Count(), Is.Not.Null.And.EquivalentTo(expectedCollection));
        }
    }
}
