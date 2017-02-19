using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
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
    public class GetAllEmployees_Should
    {
        [Test]
        public void InvokeOnce_WhenIsCalled()
        {
            var view = new Mock<ISettingsEmployeesView>();
            var employeeService = new Mock<IEmployeeService>();
            var eventArgs = new Mock<EventArgs>();

            var contracts = new List<FakeEmployee>() { new FakeEmployee() };
            view.Setup(x => x.Model.Employees).Returns(contracts).Verifiable();
            employeeService.Setup(x => x.GetAll()).Returns(contracts.AsQueryable).Verifiable();

            var presenter = new SettingsEmployeesPresenter(view.Object, employeeService.Object);

            presenter.View_GetAllEmployees(new object { }, eventArgs.Object);

            employeeService.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
