using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Utilities.Calculations;

namespace SalaryCalculator.Mvp.Presenters
{
    public class CreateFreelanceContractPresenter : Presenter<ICreateFreelanceContractView>, ICreateFreelanceContractPresenter
    {
        private const decimal PersonalInsurancePercent = 0.188m;
        private const decimal IncomeTaxPercent = 0.1m;

        private readonly ISelfEmploymentService selfEmploymentService;

        public CreateFreelanceContractPresenter(ICreateFreelanceContractView view, ISelfEmploymentService selfEmploymentService, Calculate calculate)
            : base(view)
        {
            Guard.WhenArgument<ISelfEmploymentService>(selfEmploymentService, "selfEmploymentService").IsNull().Throw();

            this.selfEmploymentService = selfEmploymentService;
            this.Calculate = calculate;
            this.View.CalculateSelfEmployment += CalculateSelfEmployment;
            this.View.CreateSelfEmployment += CreateSelfEmployment;
        }

        public Calculate Calculate { get; set; }

        public void CalculateSelfEmployment(object sender, SelfEmploymentEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.SocialSecurityIncome, "SocialSecurityIncome").IsLessThan(0).Throw();

            var selfEmployment = new SelfEmployment();
            selfEmployment.CreatedDate = DateTime.Now;
            selfEmployment.EmployeeId = 1;
            selfEmployment.GrossSalary = e.SocialSecurityIncome;

            bool isMaximum = this.Calculate.CheckMaxSocialSecurityIncome(e.SocialSecurityIncome);
            selfEmployment.SocialSecurityIncome = isMaximum ? ValidationConstants.MaxSocialSecurityIncome : e.SocialSecurityIncome;

            selfEmployment.PersonalInsurance = this.Calculate.GetPersonalInsurance(selfEmployment.SocialSecurityIncome ,PersonalInsurancePercent);
            selfEmployment.IncomeTax = (selfEmployment.GrossSalary - selfEmployment.PersonalInsurance)*IncomeTaxPercent;

            selfEmployment.NetWage = selfEmployment.GrossSalary - selfEmployment.PersonalInsurance - selfEmployment.IncomeTax;

            this.View.Model.SelfEmployment = selfEmployment;
        }

        public void CreateSelfEmployment(object sender, SelfEmploymentEventArgs e)
        {
            Guard.WhenArgument<SelfEmployment>(this.View.Model.SelfEmployment, "SelfEmployment").IsNull().IsNotInstanceOfType(typeof(SelfEmployment)).Throw();

            this.selfEmploymentService.Create(this.View.Model.SelfEmployment);
        }
    }
}
