using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Utilities.Calculations;

namespace SalaryCalculator.Mvp.Presenters
{
    public class CreateFreelanceContractPresenter : Presenter<ICreateFreelanceContractView>, ICreateFreelanceContractPresenter
    {
        private readonly ISelfEmploymentService selfEmploymentService;
        private readonly ISalaryCalculatorModelFactory modelFactory;

        public CreateFreelanceContractPresenter(ICreateFreelanceContractView view, ISelfEmploymentService selfEmploymentService, ISalaryCalculatorModelFactory modelFactory,Payroll calculate)
            : base(view)
        {
            Guard.WhenArgument<ISelfEmploymentService>(selfEmploymentService, "selfEmploymentService").IsNull().Throw();

            Guard.WhenArgument<Payroll>(calculate, "calculate").IsNull().Throw();

            this.selfEmploymentService = selfEmploymentService;
            this.modelFactory = modelFactory;
            this.Payroll = calculate;

            this.View.CalculateSelfEmployment += CalculateSelfEmployment;
            this.View.CreateSelfEmployment += CreateSelfEmployment;
        }

        public Payroll Payroll { get; set; }

        public void CalculateSelfEmployment(object sender, ISelfEmploymentEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.SocialSecurityIncome, "SocialSecurityIncome").IsLessThan(0).Throw();

            var selfEmployment = this.modelFactory.GetSelfEmployment();
            selfEmployment.CreatedDate = DateTime.Now;
            selfEmployment.EmployeeId = 1;
            selfEmployment.GrossSalary = e.SocialSecurityIncome;

            bool isMaximum = this.Payroll.CheckMaxSocialSecurityIncome(e.SocialSecurityIncome);
            selfEmployment.SocialSecurityIncome = isMaximum ? ValidationConstants.MaxSocialSecurityIncome : e.SocialSecurityIncome;

            selfEmployment.PersonalInsurance = this.Payroll.GetPersonalInsurance(selfEmployment.SocialSecurityIncome);
            selfEmployment.IncomeTax = this.Payroll.GetIncomeTax(selfEmployment.GrossSalary, selfEmployment.PersonalInsurance);

            selfEmployment.NetWage = this.Payroll.GetNetWage(selfEmployment.GrossSalary, selfEmployment.PersonalInsurance, selfEmployment.IncomeTax);

            this.View.Model.SelfEmployment = selfEmployment;
        }

        public void CreateSelfEmployment(object sender, ISelfEmploymentEventArgs e)
        {
            Guard.WhenArgument<SelfEmployment>(this.View.Model.SelfEmployment, "SelfEmployment").IsNull().IsNotInstanceOfType(typeof(SelfEmployment)).Throw();

            this.selfEmploymentService.Create(this.View.Model.SelfEmployment);
        }
    }
}
