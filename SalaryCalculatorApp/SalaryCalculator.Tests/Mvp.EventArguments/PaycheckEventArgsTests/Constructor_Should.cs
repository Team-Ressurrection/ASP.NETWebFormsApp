using System;

using NUnit.Framework;

using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Tests.Mvp.EventArguments.PaycheckEventArgsTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase(50,50,100)]
        public void SetAllProperties_WhenParametersArePassedCorrectly(decimal num1, decimal num2, decimal num3)
        {
            var date = new DateTime(2017, 2, 10);
            var eventArgs = new PaycheckEventArgs(num1, num2, num3,date);

            Assert.AreEqual(num1, eventArgs.GrossSalary);
            Assert.AreEqual(num2, eventArgs.GrossFixedBonus);
            Assert.AreEqual(num3, eventArgs.GrossNonFixedBonus);
            Assert.AreEqual(date, eventArgs.CreatedDate);
        }
    }
}
