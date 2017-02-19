using NUnit.Framework;

using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Tests.Mvp.EventArguments.ModelIdEventArgsTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetPropertyId_WithConstructorParameter()
        {
            var id = 1;
            var eventArgs = new ModelIdEventArgs(id);

            Assert.AreEqual(id, eventArgs.Id);
        }
    }
}
