using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
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
    public class ProfilePresenterTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenParametersArePassedCorrectly()
        {
            var view = new Mock<IProfileView>();
            var service = new Mock<IUserService>();

            Assert.IsInstanceOf<IProfilePresenter>(new ProfilePresenter(view.Object, service.Object));
        }
    }
}
