using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Tests.Mvp.Presenters
{
    [TestFixture]
    public class ReportLaborPresenterTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParameterServiceIsNull()
        {
            var view = new Mock<IReportLaborView>();
            var service = new Mock<IEmployeePaycheckService>();

            Assert.That(() => new ReportLaborPresenter(view.Object, null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Constructor_ShouldCreateInstanceCorrectly_WhenAllParametersArePassed()
        {
            var view = new Mock<IReportLaborView>();
            var service = new Mock<IEmployeePaycheckService>();

            Assert.IsInstanceOf<IReportLaborPresenter>(new ReportLaborPresenter(view.Object, service.Object));
        }
    }
}
