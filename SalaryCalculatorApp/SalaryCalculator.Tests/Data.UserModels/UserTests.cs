using Microsoft.AspNet.Identity.EntityFramework;
using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.UserModels
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void WhenCreatingNewUser_ShouldInheritsIdentityUserClass()
        {
            var user = new User();

            Assert.IsInstanceOf(typeof(User), user);
        }
    }
}
