using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Repositories;
using System.Linq.Expressions;

namespace SalaryCalculator.Tests.Data.Repository
{
    [TestFixture]
    public class Methods_Should
    {
        [Test]
        [Ignore("Not finished test.")]
        public void AddMethod_ShouldInvokedOnce_WhenParameterIsPassedCorrectly()
        {
            var fakeDbSet = new Mock<DbSet<FakeEmployee>>();

            var fakeDbModel = new FakeEmployee()
            {
                FirstName = "Alexander",
                MiddleName = "Vasilev",
                LastName = "Petrov",
                Id = 1,
                PersonalId = "8010106060"
            };

            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            repo.Add(fakeDbModel);

            mockDbContext.Verify(x => x.Entry<FakeEmployee>(fakeDbModel), Times.Once);
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
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<FakeEmployee, bool>> filter = null;
            Assert.That(
            () => repo.GetAll(filter),
            Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }

        [Test]
        [Ignore("Not finished test.")]
        public void ShouldPassCorrectly_WhenFilterParameterIsValid()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            repo.Add(new FakeEmployee() { FirstName = "Alexander" });
            repo.Add(new FakeEmployee() { FirstName = "Ivan" });
            repo.Add(new FakeEmployee() { FirstName = "Georgi" });
            Expression<Func<FakeEmployee, bool>> filter = (FakeEmployee empl) => empl.FirstName.Equals("Alexander");

            var actualResult = repo.GetAll(filter);
            Assert.That(actualResult.Count, Is.EqualTo(0));
        }

        [Test]
        [Ignore("Not finished test.")]
        public void ShouldReturnCorrectCountOfItem_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            var fakeModel = new Mock<FakeEmployee>();
            fakeModel.SetupGet(model => model.Id).Returns(1);

            var fakeData = new List<FakeEmployee>()
            {
                fakeModel.Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object,
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<FakeEmployee, bool>> filter = (FakeEmployee model) => model.Id == 1;

            var actualReturnedCollection = repo.GetAll(filter);

            var expectedCollection = new List<FakeEmployee>() { fakeModel.Object };

            Assert.That(actualReturnedCollection.Count(), Is.Not.Null.And.EquivalentTo(expectedCollection));
        }

        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenEntityIsNullable()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            Assert.That(() => repo.Add(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenEntityIsNullable()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            Assert.That(() => repo.Delete(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }

        [Test]
        public void Update_ShouldThrowArgumentNullException_WhenEntityIsNullable()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            Assert.That(() => repo.Update(null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null."));
        }

        [Test]
        [Ignore("Not finished test.")]
        public void GetAll_ShouldReturnAllData_WhenIsCalled()
        {
            var mockDbSet = new Mock<DbSet<FakeEmployee>>();
            var mockDbContext = new Mock<ISalaryCalculatorDbContext>();
            mockDbContext.Setup(mock => mock.Set<FakeEmployee>()).Returns(mockDbSet.Object);

            var repo = new SalaryCalculatorRepository<FakeEmployee>(mockDbContext.Object);

            var fakeModel = new Mock<FakeEmployee>();

            var fakeData = new List<FakeEmployee>()
            {
                fakeModel.Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object,
                new Mock<FakeEmployee>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<FakeEmployee>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var employees = repo.GetAll();

            Assert.AreEqual(fakeData.Count(), employees.Count());
        }
    }
}
