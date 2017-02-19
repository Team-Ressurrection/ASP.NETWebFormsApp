using NUnit.Framework;

using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Tests.Mvp.EventArguments.EmployeeEventArgsTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase("Petar", "Petrov", "Vasilev", "8001016060")]
        public void CreateInstance_WhenAllParametersArePassedCorrectly(string firstName, string middleName, string lastName, string id)
        {
            var employeeEventArgs = new EmployeeEventArgs(firstName, middleName, lastName, id);

            Assert.IsInstanceOf<IEmployeeEventArgs>(employeeEventArgs);
        }
    }
}
