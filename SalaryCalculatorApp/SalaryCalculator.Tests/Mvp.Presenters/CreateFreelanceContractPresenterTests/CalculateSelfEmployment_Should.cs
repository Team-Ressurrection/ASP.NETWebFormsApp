using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Factories;

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
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var presenter = new CreateFreelanceContractPresenter(view.Object, service.Object, modelFactory.Object,calculate);
            var e = new Mock<ISelfEmploymentEventArgs>();
            e.Setup(x => x.SocialSecurityIncome).Returns(obj1);
            e.Setup(x => x.AdditionalSocialSecurityIncome).Returns(obj2);
            e.Setup(x => x.IsInsuredForGeneralDiseaseAndMaternity).Returns(state);
            modelFactory.Setup(x => x.GetSelfEmployment()).Returns(new FakeSelfEmployment());

            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.CalculateSelfEmployment(new object { }, e.Object));
        }

        [TestCase(460, 0, false)]
        public void CalculateSelfEmployment_ShouldSetSocialSecurityIncomeCorrectly_WhenEventArgsParamIsPassedCorrectly(decimal obj1, decimal obj2, bool state)
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var service = new Mock<ISelfEmploymentService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var presenter = new CreateFreelanceContractPresenter(view.Object, service.Object,modelFactory.Object, calculate);
            var e = new Mock<ISelfEmploymentEventArgs>();

            view.SetupProperty(x => x.Model.SelfEmployment, new FakeSelfEmployment());
            e.Setup(x => x.SocialSecurityIncome).Returns(obj1);
            e.Setup(x => x.AdditionalSocialSecurityIncome).Returns(obj2);
            e.Setup(x => x.IsInsuredForGeneralDiseaseAndMaternity).Returns(state);
            modelFactory.Setup(x => x.GetSelfEmployment()).Returns(new FakeSelfEmployment());

            presenter.CalculateSelfEmployment(new object { }, e.Object);

            Assert.AreEqual(obj1, view.Object.Model.SelfEmployment.SocialSecurityIncome);
        }
    }
}
