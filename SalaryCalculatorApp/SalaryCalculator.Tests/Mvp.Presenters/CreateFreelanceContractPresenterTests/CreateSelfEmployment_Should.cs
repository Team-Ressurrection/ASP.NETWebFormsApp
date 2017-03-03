using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Factories;

namespace SalaryCalculator.Tests.Mvp.Presenters.CreateFreelanceContractPresenterTests
{
    [TestFixture]
    public class CreateSelfEmployment_Should
    {
        [Test]
        public void CreateSelfEmployment_ShouldPassWithoutError()
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var selfEmplService = new Mock<ISelfEmploymentService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();


            var obj = new object { };
            var salary = new decimal();
            var date = new DateTime(2016, 12, 24);
            var e = new Mock<SelfEmploymentEventArgs>(salary, date, 0m, false);
            var insurance = new FakeSelfEmployment();
            view.SetupProperty(x => x.Model.Employee, new FakeEmployee() { Id = 100 });
            view.SetupGet(x => x.Model.SelfEmployment).Returns(insurance);
            modelFactory.Setup(x => x.GetSelfEmployment()).Returns(new FakeSelfEmployment());

            var presenter = new CreateFreelanceContractPresenter(view.Object, selfEmplService.Object, employeeService.Object, modelFactory.Object, calculate);

            presenter.CreateSelfEmployment(obj, e.Object);

            selfEmplService.Verify(x => x.Create(insurance), Times.Once);
        }

        [Test]
        public void CreateSelfEmployment_ShouldThrowArgumentNullException()
        {
            var view = new Mock<ICreateFreelanceContractView>();
            var selfEmplService = new Mock<ISelfEmploymentService>();
            var employeeService = new Mock<IEmployeeService>();
            var modelFactory = new Mock<ISalaryCalculatorModelFactory>();
            var calculate = new FakePayroll();

            var obj = new object { };
            var salary = new decimal();
            var date = new DateTime(2017, 1, 30);
            var e = new Mock<SelfEmploymentEventArgs>(salary, date, 0m, false);
            SelfEmployment insurance = null;

            view.SetupGet(x => x.Model.SelfEmployment).Returns(insurance);
            modelFactory.Setup(x => x.GetSelfEmployment()).Returns(new FakeSelfEmployment());

            var presenter = new CreateFreelanceContractPresenter(view.Object, selfEmplService.Object, employeeService.Object, modelFactory.Object, calculate);

            Assert.Throws<ArgumentNullException>(() => presenter.CreateSelfEmployment(obj, e.Object));
        }
    }
}
