using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.UserModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenCreatingNewUser_ShouldInheritsIdentityUserClass()
        {
            var user = new User();

            Assert.IsInstanceOf(typeof(User), user);
        }

        [Test]
        public void WhenCreatingNewUser_ShouldHavePropertyCompanyName()
        {
            var user = new User();

            user.CompanyName = "Firma";

            Assert.IsAssignableFrom(typeof(string), user.CompanyName);
        }

        [Test]
        public void WhenCreatingNewUser_ShouldHavePropertyCompanyAddress()
        {
            var user = new User();

            user.CompanyAddress = "bulevard Bulgaria";

            Assert.IsAssignableFrom(typeof(string), user.CompanyAddress);
        }
    }
}
