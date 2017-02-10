using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters
{
    [TestFixture]
    public class CreateLaborContractPresenterTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            var view = new Mock<ICreateLaborContractView>();
            var service = new Mock<IEmployeePaycheckService>();

            Assert.IsInstanceOf<ICreateLaborContractPresenter>(new CreateLaborContractPresenter(view.Object, service.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenServiceParameterIsNull()
        {
            var view = new Mock<ICreateLaborContractView>();

            Assert.Throws<ArgumentNullException>(() => new CreateLaborContractPresenter(view.Object, null));
        }
    }
}
