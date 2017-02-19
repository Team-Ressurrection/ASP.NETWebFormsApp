using System;
using System.Web.ModelBinding;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Tests.Mvp.Presenters.SettingsLaborContractsPresenterTests
{
    [TestFixture]
    public class View_UpdateSelfEmployment_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            var view = new Mock<ISettingsFreelanceContractsView>();
            view.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int selfEmploymentId = 1;
            string expectedError = String.Format("SelfEmployment with id {0} was not found", selfEmploymentId);
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            selfEmploymentService.Setup(c => c.GetById(selfEmploymentId)).Returns<SelfEmployment>(null);

            ISettingsFreelanceContractsPresenter presenter = new SettingsFreelanceContractsPresenter
                (view.Object, selfEmploymentService.Object);

            view.Raise(v => v.UpdateModel += null, new ModelIdEventArgs(selfEmploymentId));

            Assert.AreEqual(1, view.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, view.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }
    }
}
