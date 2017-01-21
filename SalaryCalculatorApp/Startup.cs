using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalaryCalculatorApp.Startup))]
namespace SalaryCalculatorApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
