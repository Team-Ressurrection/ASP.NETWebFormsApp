using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Factories;

namespace SalaryCalculator.Mvp.Presenters.JobContracts
{
    public class CreateNonLaborContractPresenter : Presenter<ICreateNonLaborContractView>, ICreateNonLaborContractPresenter
    {
        private readonly IRemunerationBillService remunerationBillService;
        private readonly ISalaryCalculatorModelFactory modelFactory;

        public CreateNonLaborContractPresenter(ICreateNonLaborContractView view, IRemunerationBillService remunerationBillService, ISalaryCalculatorModelFactory modelFactory,Payroll calculate)
            : base(view)
        {
            Guard.WhenArgument<IRemunerationBillService>(remunerationBillService, "remunerationBillService").IsNull().Throw();

            Guard.WhenArgument<Payroll>(calculate, "calculate").IsNull().Throw();


            this.remunerationBillService = remunerationBillService;
            this.modelFactory = modelFactory;
            this.Payroll = calculate;

            this.View.CalculateRemunerationBill += CalculateRemunerationBill;
            this.View.CreateRemunerationBill += CreateRemunerationBill;
        }

        public Payroll Payroll { get; set; }

        public void CalculateRemunerationBill(object sender, IRemunerationBillEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.GrossSalary, "GrossSalary").IsLessThan(0).Throw();

            var remunerationBill = this.modelFactory.GetRemunerationBill();
            remunerationBill.CreatedDate = DateTime.Now;
            remunerationBill.EmployeeId = 1;
            remunerationBill.GrossSalary = e.GrossSalary;

            bool isMaximum = this.Payroll.CheckMaxSocialSecurityIncome(e.GrossSalary);
            remunerationBill.SocialSecurityIncome = isMaximum ? ValidationConstants.MaxSocialSecurityIncome : e.GrossSalary;

            remunerationBill.PersonalInsurance = this.Payroll.GetPersonalInsurance(remunerationBill.SocialSecurityIncome);
            remunerationBill.IncomeTax = this.Payroll.GetIncomeTax(remunerationBill.GrossSalary, remunerationBill.PersonalInsurance);

            remunerationBill.NetWage = this.Payroll.GetNetWage(remunerationBill.GrossSalary,remunerationBill.PersonalInsurance,remunerationBill.IncomeTax);

            this.View.Model.RemunerationBill = remunerationBill;
        }

        public void CreateRemunerationBill(object sender, IRemunerationBillEventArgs e)
        {
            Guard.WhenArgument<RemunerationBill>(this.View.Model.RemunerationBill, "RemunerationBill").IsNull().IsNotInstanceOfType(typeof(RemunerationBill)).Throw();

            this.remunerationBillService.Create(this.View.Model.RemunerationBill);
        }
    }
}
