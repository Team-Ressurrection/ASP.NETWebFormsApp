using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalaryCalculator.Startup))]
namespace SalaryCalculator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
