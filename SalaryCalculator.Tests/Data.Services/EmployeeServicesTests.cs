using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.Services
{
    [TestFixture]
    public class EmployeeServicesTests
    {
        [Test]
        public void Constructor_WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);
        }
    }
}
