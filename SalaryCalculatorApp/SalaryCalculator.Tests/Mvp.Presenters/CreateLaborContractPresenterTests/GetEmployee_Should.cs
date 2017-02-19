using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateLaborContractPresenterTests
{
    [TestFixture]
    public class GetEmployee_Should
    {
        [Test]
        public void CreateNewEmployee_WhenIsInvoked()
        {
            var view = new Mock<ICreateLaborContractView>();
            var selfEmplService = new Mock<IEmployeePaycheckService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();
            var eventArgs = new Mock<IEmployeeEventArgs>();

            eventArgs.Setup(x => x.FirstName).Returns("Vasil").Verifiable();
            eventArgs.Setup(x => x.MiddleName).Returns("Vasilev").Verifiable();
            eventArgs.Setup(x => x.LastName).Returns("Vasilev").Verifiable();
            eventArgs.Setup(x => x.PersonalId).Returns("8612125050").Verifiable();

            var employee = new FakeEmployee();
            modelFactory.Setup(x => x.GetEmployee()).Returns(employee).Verifiable();

            view.Setup(x => x.Model.Employee).Returns(employee).Verifiable();

            var presenter = new CreateLaborContractPresenter(view.Object, selfEmplService.Object, employeeService.Object, modelFactory.Object, calculate);

            presenter.GetEmployee(new object { }, eventArgs.Object);

            employeeService.Verify(x => x.Create(employee), Times.Once);
        }
    }
}
