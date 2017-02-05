using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Binder;

using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject;

using SalaryCalculator.Factory;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Repositories;
using Ninject.Web.Common;
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

            this.Bind<IReportNonLaborPresenter>().To<ReportNonLaborPresenter>();

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