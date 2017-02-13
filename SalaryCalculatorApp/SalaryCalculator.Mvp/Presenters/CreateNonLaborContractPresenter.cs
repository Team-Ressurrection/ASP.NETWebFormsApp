using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Models.Constants;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
    public class CreateNonLaborContractPresenter : Presenter<ICreateNonLaborContractView>, ICreateNonLaborContractPresenter
    {
        private const decimal PersonalInsurancePercent = 0.188m;
        private const decimal IncomeTaxPercent = 0.1m;

        private readonly IRemunerationBillService remunerationBillService;

        public CreateNonLaborContractPresenter(ICreateNonLaborContractView view, IRemunerationBillService remunerationBillService)
            : base(view)
        {
            Guard.WhenArgument<IRemunerationBillService>(remunerationBillService, "remunerationBillService").IsNull().Throw();

            this.remunerationBillService = remunerationBillService;

            this.View.CalculateRemunerationBill += CalculateRemunerationBill;
            this.View.CreateRemunerationBill += CreateRemunerationBill;
        }

        public void CalculateRemunerationBill(object sender, RemunerationBillEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.GrossSalary, "GrossSalary").IsLessThan(0).Throw();

            var remunerationBill = new RemunerationBill();
            remunerationBill.CreatedDate = DateTime.Now;
            remunerationBill.EmployeeId = 1;
            remunerationBill.GrossSalary = e.GrossSalary;

            bool isMaximum = this.CheckMaxSocialSecurityIncome(e.GrossSalary);
            remunerationBill.SocialSecurityIncome = isMaximum ? ValidationConstants.MaxSocialSecurityIncome : e.GrossSalary;

            remunerationBill.PersonalInsurance = this.GetPersonalInsurance(remunerationBill.SocialSecurityIncome ,PersonalInsurancePercent);
            remunerationBill.IncomeTax = (remunerationBill.GrossSalary - remunerationBill.PersonalInsurance)*IncomeTaxPercent;

            remunerationBill.NetWage = remunerationBill.GrossSalary - remunerationBill.PersonalInsurance - remunerationBill.IncomeTax;

            this.View.Model.RemunerationBill = remunerationBill;
        }

        public void CreateRemunerationBill(object sender, RemunerationBillEventArgs e)
        {
            Guard.WhenArgument<RemunerationBill>(this.View.Model.RemunerationBill, "RemunerationBill").IsNull().IsNotInstanceOfType(typeof(RemunerationBill)).Throw();

            this.remunerationBillService.Create(this.View.Model.RemunerationBill);
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
    }
}
