using System;
using System.Linq;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Web.Common;

using WebFormsMvp;
using WebFormsMvp.Binder;

using SalaryCalculator.Data;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Repositories;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.Factories;
using SalaryCalculator.Mvp.Presenters.Account;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Presenters.Reports;
using SalaryCalculator.Utilities.Calculations;

namespace SalaryCalculator.App_Start
{
    public class SalaryCalculatorNinjectModule : NinjectModule
    {

        public override void Load()
        {
            this.Bind<ISalaryCalculatorDbContext>().To<SalaryCalculatorDbContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(SalaryCalculatorRepository<>)).InSingletonScope();

            this.Bind<IRemunerationBillService>().To<RemunerationBillService>().InRequestScope();
            this.Bind<IEmployeePaycheckService>().To<EmployeePaycheckService>().InRequestScope();
            this.Bind<IUserService>().To<UserService>().InRequestScope();
            this.Bind<ISelfEmploymentService>().To<SelfEmploymentService>().InRequestScope();
            this.Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();

            this.Bind<User>().ToSelf();
            this.Bind<Employee>().ToSelf();
            this.Bind<RemunerationBill>().ToSelf();
            this.Bind<EmployeePaycheck>().ToSelf();
            this.Bind<SelfEmployment>().ToSelf();

            this.Bind<ICreateLaborContractPresenter>().To<CreateLaborContractPresenter>();
            this.Bind<ICreateNonLaborContractPresenter>().To<CreateNonLaborContractPresenter>();
            this.Bind<IReportNonLaborPresenter>().To<ReportNonLaborPresenter>();
            this.Bind<IReportLaborPresenter>().To<ReportLaborPresenter>();
            this.Bind<IProfilePresenter>().To<ProfilePresenter>();

            this.Bind<Payroll>().ToSelf();

            this.Bind<ISalaryCalculatorModelFactory>().To<SalaryCalculatorModelFactory>().InSingletonScope();
            this.Bind<ISalaryCalculatorEventArgsFactory>().To<SalaryCalculatorEventArgsFactory>().InSingletonScope();
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