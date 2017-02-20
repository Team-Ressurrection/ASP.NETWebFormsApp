using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Models;
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
using System.Web.ModelBinding;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsLaborContractsPresenterTests
{
    [TestFixture]
    public class View_UpdatePaycheck_Should
    {
        [Test]
        public void AddModelError_WhenPaycheckIsNotFound()
        {
            var view = new Mock<ISettingsLaborContractsView>();
            view.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int paycheckId = 1;
            string expectedError = String.Format("EmployeePaycheck with id {0} was not found", paycheckId);
            var paycheckService = new Mock<IEmployeePaycheckService>();
            paycheckService.Setup(c => c.GetById(paycheckId)).Returns<EmployeePaycheck>(null);

            ISettingsLaborContractsPresenter presenter = new SettingsLaborContractsPresenter
                (view.Object, paycheckService.Object);

            view.Raise(v => v.UpdateModel += null, new ModelIdEventArgs(paycheckId));

            Assert.AreEqual(1, view.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, view.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void TryUpdateModelIsNotCalled_WhenEmployeePaycheckIsNotFound()
        {
            var view = new Mock<ISettingsLaborContractsView>();
            view.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int paycheckId = 1;
            var paycheckService = new Mock<IEmployeePaycheckService>();
            paycheckService.Setup(c => c.GetById(paycheckId)).Returns<EmployeePaycheck>(null);

            ISettingsLaborContractsPresenter presenter = new SettingsLaborContractsPresenter
                (view.Object, paycheckService.Object);

            view.Raise(v => v.UpdateModel += null, new ModelIdEventArgs(paycheckId));

            view.Verify(v => v.TryUpdateModel(It.IsAny<EmployeePaycheck>()), Times.Never());
        }

        [Test]
        public void UpdateByIdIsCalled_WhenEmployeePaycheckIsFoundAndIsInValidState()
        {
            var view = new Mock<ISettingsLaborContractsView>();
            view.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            int paycheckId = 1;
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var paycheck = new FakeEmployeePaycheck() { Id = paycheckId };
            paycheckService.Setup(c => c.GetById(paycheckId)).Returns(paycheck);

            ISettingsLaborContractsPresenter presenter = new SettingsLaborContractsPresenter
                (view.Object, paycheckService.Object);

            view.Raise(v => v.UpdateModel += null, new ModelIdEventArgs(paycheckId));

            paycheckService.Verify(c => c.UpdateById(paycheckId, paycheck), Times.Once());
        }
    }
}
