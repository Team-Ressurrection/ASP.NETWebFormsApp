﻿using Microsoft.AspNet.Identity.EntityFramework;
using NUnit.Framework;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.DbContext
{
    [TestFixture]
    public class SalaryCalculatorDbContextTests
    {
        [Test]
        public void ConstructorWhenPassed_ShouldCreateInstance()
        {
            IdentityDbContext<User> dbContext = new SalaryCalculatorDbContext();

            Assert.IsInstanceOf<SalaryCalculatorDbContext>(dbContext);
        }

        [Test]
        public void DbContext_ShouldHave_DbSetPropertyEmployees()
        {
            ISalaryCalculatorDbContext dbContext = new SalaryCalculatorDbContext();

            var dbSetEmployees = dbContext.Set<FakeEmployee>();

            Assert.IsInstanceOf(typeof(IDbSet<Employee>), dbSetEmployees);
        }
    }
}