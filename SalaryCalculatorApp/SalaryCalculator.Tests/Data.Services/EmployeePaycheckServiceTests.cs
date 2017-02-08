using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.Services
{
    [TestFixture]
    public class EmployeePaycheckServiceTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenParameterIRepositoryIsPassedCorrectly()
        {
            var repo = new Mock<IRepository<EmployeePaycheck>>();

            var paycheckService = new EmployeePaycheckService(repo.Object);

            Assert.IsInstanceOf<IEmployeePaycheckService>(paycheckService);
        }
    }
}
