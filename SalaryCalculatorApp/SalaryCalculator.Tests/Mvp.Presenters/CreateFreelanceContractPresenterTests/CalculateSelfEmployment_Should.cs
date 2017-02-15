using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateFreelanceContractPresenterTests
{
    [TestFixture]
    public class CalculateSelfEmployment_Should
    {
        [TestCase(-10, 0, false)]
        [TestCase(-1, 0, false)]
        [TestCase(-0.01, 0, false)]
        public void CalculateSelfEmployment_ShouldThrowException_WhenEventArgsParamIsLessThanZero(decimal obj1, decimal obj2, bool state)
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var service = new Mock<ISelfEmploymentService>();
            var calculate = new FakePayroll();

            var presenter = new CreateFreelanceContractPresenter(view.Object, service.Object, calculate);
            var e = new Mock<SelfEmploymentEventArgs>(obj1, obj2, state);

            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.CalculateSelfEmployment(new object { }, e.Object));
        }

        [TestCase(460, 0, false)]
        public void CalculateSelfEmployment_ShouldSetSocialSecurityIncomeCorrectly_WhenEventArgsParamIsPassedCorrectly(decimal obj1, decimal obj2, bool state)
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var service = new Mock<ISelfEmploymentService>();
            var calculate = new FakePayroll();

            var presenter = new CreateFreelanceContractPresenter(view.Object, service.Object, calculate);
            var e = new Mock<SelfEmploymentEventArgs>(obj1, obj2, state);

            view.SetupProperty(x => x.Model.SelfEmployment, new FakeSelfEmployment());

            presenter.CalculateSelfEmployment(new object { }, e.Object);

            Assert.AreEqual(obj1, view.Object.Model.SelfEmployment.SocialSecurityIncome);
        }
    }
}
