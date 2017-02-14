using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Mvp.Presenters
{
    public class CreateLaborContractPresenter : Presenter<ICreateLaborContractView>, ICreateLaborContractPresenter
    {
        private const decimal PersonalInsurancePercent = 0.188m;
        private const decimal IncomeTaxPercent = 0.1m;

        private readonly IEmployeePaycheckService paycheckService;

        public CreateLaborContractPresenter(ICreateLaborContractView view, IEmployeePaycheckService paycheckService)
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService").IsNull().Throw();

            this.paycheckService = paycheckService;

            this.View.CalculatePaycheck += CalculatePaycheck;
            this.View.CreatePaycheck += CreatePaycheck;
        }

        public void CalculatePaycheck(object sender, PaycheckEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.GrossFixedBonus, "GrossFixedBonus").IsLessThan(0).Throw();
            Guard.WhenArgument<decimal>(e.GrossNonFixedBonus, "GrossNonFixedBonus").IsLessThan(0).Throw();
            Guard.WhenArgument<decimal>(e.GrossSalary, "GrossSalary").IsLessThan(0).Throw();

            var paycheck = new EmployeePaycheck();
            paycheck.CreatedDate = DateTime.Now;
            paycheck.EmployeeId = 1;
            paycheck.GrossFixedBonus = e.GrossFixedBonus;
            paycheck.GrossNonFixedBonus = e.GrossNonFixedBonus;
            paycheck.GrossSalary = e.GrossSalary;

            var parameters = new List<decimal>();
            parameters.Add(e.GrossFixedBonus);
            parameters.Add(e.GrossNonFixedBonus);
            parameters.Add(e.GrossSalary);

            decimal grossSalary = this.GetGrossSalary(parameters);
            bool isMaximum = this.CheckMaxSocialSecurityIncome(grossSalary);
            paycheck.SocialSecurityIncome = isMaximum ? ValidationConstants.MaxSocialSecurityIncome : e.GrossFixedBonus + e.GrossNonFixedBonus + e.GrossSalary;

            paycheck.PersonalInsurance = this.GetPersonalInsurance(paycheck.SocialSecurityIncome ,PersonalInsurancePercent);
            paycheck.IncomeTax = (grossSalary - paycheck.PersonalInsurance)*IncomeTaxPercent;

            paycheck.NetWage = grossSalary - paycheck.PersonalInsurance - paycheck.IncomeTax;

            this.View.Model.EmployeePaycheck = paycheck;
             
        }

        public void CreatePaycheck(object sender, PaycheckEventArgs e)
        {
            Guard.WhenArgument<EmployeePaycheck>(this.View.Model.EmployeePaycheck, "EmployeePaycheck").IsNull().IsNotInstanceOfType(typeof(EmployeePaycheck)).Throw();

            this.paycheckService.Create(this.View.Model.EmployeePaycheck);
        }
        private decimal GetPersonalInsurance(decimal salary, decimal personalInsurancePercent)
        {
            return salary * personalInsurancePercent;
        }

        private bool CheckMaxSocialSecurityIncome(decimal parameter)
        {
            var isMaximum = parameter.CompareTo(ValidationConstants.MaxSocialSecurityIncome) >= 0;

            return isMaximum;
        }

        private decimal GetGrossSalary(IEnumerable<decimal> parameters)
        {
            return parameters.Sum();
        }
    }
}
