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
            var selfEmplService = new Mock<ISelfEmploymentService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var e = new Mock<ISelfEmploymentEventArgs>();
            e.Setup(x => x.SocialSecurityIncome).Returns(obj1);
            e.Setup(x => x.AdditionalSocialSecurityIncome).Returns(obj2);
            e.Setup(x => x.IsInsuredForGeneralDiseaseAndMaternity).Returns(state);
            modelFactory.Setup(x => x.GetSelfEmployment()).Returns(new FakeSelfEmployment());

            var presenter = new CreateFreelanceContractPresenter(view.Object, selfEmplService.Object, employeeService.Object, modelFactory.Object, calculate);

            Assert.Throws<ArgumentOutOfRangeException>(() => presenter.CalculateSelfEmployment(new object { }, e.Object));
        }

        [TestCase(460, 0, false)]
        public void CalculateSelfEmployment_ShouldSetSocialSecurityIncomeCorrectly_WhenEventArgsParamIsPassedCorrectly(decimal obj1, decimal obj2, bool state)
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var selfEmplService = new Mock<ISelfEmploymentService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var e = new Mock<ISelfEmploymentEventArgs>();

            view.SetupProperty(x => x.Model.Employee, new FakeEmployee() { Id = 15 });
            view.SetupProperty(x => x.Model.SelfEmployment, new FakeSelfEmployment());
            e.Setup(x => x.SocialSecurityIncome).Returns(obj1);
            e.Setup(x => x.AdditionalSocialSecurityIncome).Returns(obj2);
            e.Setup(x => x.IsInsuredForGeneralDiseaseAndMaternity).Returns(state);
            modelFactory.Setup(x => x.GetSelfEmployment()).Returns(new FakeSelfEmployment());

            var presenter = new CreateFreelanceContractPresenter(view.Object, selfEmplService.Object, employeeService.Object, modelFactory.Object, calculate);

            presenter.CalculateSelfEmployment(new object { }, e.Object);

            Assert.AreEqual(obj1, view.Object.Model.SelfEmployment.SocialSecurityIncome);
        }
    }
}
