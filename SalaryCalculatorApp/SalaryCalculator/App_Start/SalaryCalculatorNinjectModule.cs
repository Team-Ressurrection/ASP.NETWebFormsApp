using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Binder;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Web.Common;

using SalaryCalculator.Data;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Repositories;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factory;
using SalaryCalculator.Mvp.Presenters;

namespace SalaryCalculator.App_Start
{
    public class SalaryCalculatorNinjectModule : NinjectModule
    {

        public override void Load()
        {
            this.Bind<ISalaryCalculatorDbContext>().To<SalaryCalculatorDbContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(SalaryCalculatorRepository<>));
            this.Bind<IRemunerationBillService>().To<RemunerationBillService>();
            this.Bind<IEmployeePaycheckService>().To<EmployeePaycheckService>();
            this.Bind<IUserService>().To<UserService>();

            this.Bind<IReportNonLaborPresenter>().To<ReportNonLaborPresenter>();
            this.Bind<IReportLaborPresenter>().To<ReportLaborPresenter>();

            this.Bind<IPresenterFactory>().To<SalaryCalculatorPresenterFactory>().InSingletonScope();

            this.Bind<ISalaryCalculatorPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>().ToMethod(this.GetPresenter).NamedLikeFactoryMethod((ISalaryCalculatorPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorParamter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorParamter);
        }
    }
}