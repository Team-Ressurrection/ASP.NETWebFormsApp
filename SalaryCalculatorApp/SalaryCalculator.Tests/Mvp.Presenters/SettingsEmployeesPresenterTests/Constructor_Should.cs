using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsEmployeesPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ISettingsEmployeesView>();
            var employeeService = new Mock<IEmployeeService>();

            var presenter = new SettingsEmployeesPresenter(view.Object, employeeService.Object);

            Assert.IsInstanceOf<ISettingsEmployeesPresenter>(presenter);
        }

        [Test]
        public void ThrowArgumentNullException_WhenEmployeeServiceParametersIsNull()
        {
            var view = new Mock<ISettingsEmployeesView>();

            Assert.Throws<ArgumentNullException>(()=> new SettingsEmployeesPresenter(view.Object, null));
        }
    }
}
