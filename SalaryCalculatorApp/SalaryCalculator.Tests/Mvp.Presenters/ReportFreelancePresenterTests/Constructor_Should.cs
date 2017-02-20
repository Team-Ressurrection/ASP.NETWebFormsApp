using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Mvp.Views.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Mvp.Presenters.ReportFreelancePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParameterServiceIsNull()
        {
            var view = new Mock<IReportFreelanceView>();
            var service = new Mock<ISelfEmploymentService>();

            Assert.That(() => new ReportFreelancePresenter(view.Object, null), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Constructor_ShouldCreateInstanceCorrectly_WhenAllParametersArePassed()
        {
            var view = new Mock<IReportFreelanceView>();
            var service = new Mock<ISelfEmploymentService>();

            Assert.IsInstanceOf<IReportFreelancePresenter>(new ReportFreelancePresenter(view.Object, service.Object));
        }
    }
}
