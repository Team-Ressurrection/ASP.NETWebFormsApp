using System;

using NUnit.Framework;

using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Tests.Mvp.EventArguments.RemunerationBillEventArgsTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase(1000)]
        public void SetAllProperties_WhenAllParametersArePassedCorrectly(decimal num1)
        {
            var date = new DateTime(2017, 1, 31);
            var eventArgs = new RemunerationBillEventArgs(num1,date);

            Assert.AreEqual(num1, eventArgs.GrossSalary);
        }
    }
}
