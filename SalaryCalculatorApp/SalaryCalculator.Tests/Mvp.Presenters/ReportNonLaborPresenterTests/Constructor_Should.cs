using System;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Mvp.Views.Reports;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Mvp.Presenters.ReportNonLaborPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParameterServiceIsNull()
        {
            var view = new Mock<IReportNonLaborView>();
            var service = new Mock<ISelfEmploymentService>();

            Assert.That(() => new ReportNonLaborPresenter(view.Object, null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Constructor_ShouldCreateInstanceCorrectly_WhenAllParametersArePassed()
        {
            var view = new Mock<IReportNonLaborView>();
            var service = new Mock<IRemunerationBillService>();
            var repo = new Mock<IRepository<RemunerationBill>>();
            var bill = new FakeEmployeePaycheck();

            IReportNonLaborPresenter presenter = new ReportNonLaborPresenter(view.Object, service.Object);

            Assert.IsInstanceOf<IReportNonLaborPresenter>(presenter);
        }
    }
}
