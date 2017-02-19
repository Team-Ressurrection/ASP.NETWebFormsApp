using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using SalaryCalculator.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsEmployeesPresenterTests
{
    [TestFixture]
    public class View_DeleteEmployee_Should
    {
        [Test]
        public void InvokeOnce_WhenIsCalled()
        {
            var view = new Mock<ISettingsEmployeesView>();
            var employeeService = new Mock<IEmployeeService>();

            var employees = new List<FakeEmployee>()
            {
                new FakeEmployee() {Id=1 },
                new FakeEmployee() {Id=2 }
            };
            int id = 1;

            view.Setup(x => x.Model.Employees).Returns(employees).Verifiable();
            employeeService.Setup(x => x.DeleteById(id)).Verifiable();

            var presenter = new SettingsEmployeesPresenter(view.Object, employeeService.Object);
            presenter.View_DeleteEmployee(new object { }, new ModelIdEventArgs(id));

            employeeService.Verify(x => x.DeleteById(id), Times.Once);
        }
    }
}
