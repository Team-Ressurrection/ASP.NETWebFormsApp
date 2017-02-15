using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Mvp.Presenters
{
    public class CreateLaborContractPresenter : Presenter<ICreateLaborContractView>, ICreateLaborContractPresenter
    {
        private const decimal PersonalInsurancePercent = 0.188m;
        private const decimal IncomeTaxPercent = 0.1m;

        private readonly IEmployeePaycheckService paycheckService;

        public CreateLaborContractPresenter(ICreateLaborContractView view, IEmployeePaycheckService paycheckService, Payroll calculate)
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService").IsNull().Throw();

            Guard.WhenArgument<Payroll>(calculate, "calculate").IsNull().Throw();

            this.paycheckService = paycheckService;

            this.Payroll = calculate;

            this.View.CalculatePaycheck += CalculatePaycheck;
            this.View.CreatePaycheck += CreatePaycheck;
        }

        public Payroll Payroll { get; set; }

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

            decimal grossSalary = this.Payroll.GetGrossSalary(parameters);
            bool isMaximum = this.Payroll.CheckMaxSocialSecurityIncome(grossSalary);
            paycheck.SocialSecurityIncome = isMaximum ? ValidationConstants.MaxSocialSecurityIncome : e.GrossFixedBonus + e.GrossNonFixedBonus + e.GrossSalary;

            paycheck.PersonalInsurance = this.Payroll.GetPersonalInsurance(paycheck.SocialSecurityIncome ,PersonalInsurancePercent);
            paycheck.IncomeTax = (grossSalary - paycheck.PersonalInsurance)*IncomeTaxPercent;

            paycheck.NetWage = grossSalary - paycheck.PersonalInsurance - paycheck.IncomeTax;

            this.View.Model.EmployeePaycheck = paycheck;
             
        }

        public void CreatePaycheck(object sender, PaycheckEventArgs e)
        {
            Guard.WhenArgument<EmployeePaycheck>(this.View.Model.EmployeePaycheck, "EmployeePaycheck").IsNull().IsNotInstanceOfType(typeof(EmployeePaycheck)).Throw();

            this.paycheckService.Create(this.View.Model.EmployeePaycheck);
        }
    }
}
