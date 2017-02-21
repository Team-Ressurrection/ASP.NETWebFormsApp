using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Mvp.Presenters.JobContracts
{
    public class CreateNonLaborContractPresenter : Presenter<ICreateNonLaborContractView>, ICreateNonLaborContractPresenter
    {
        private readonly IRemunerationBillService remunerationBillService;
        private readonly IEmployeeService employeeService;
        private readonly ISalaryCalculatorModelFactory modelFactory;

        public CreateNonLaborContractPresenter(ICreateNonLaborContractView view, IRemunerationBillService remunerationBillService, IEmployeeService employeeService,ISalaryCalculatorModelFactory modelFactory,Payroll calculate)
            : base(view)
        {
            Guard.WhenArgument<IRemunerationBillService>(remunerationBillService, "remunerationBillService").IsNull().Throw();

            Guard.WhenArgument<IEmployeeService>(employeeService, "employeeService").IsNull().Throw();

            Guard.WhenArgument<ISalaryCalculatorModelFactory>(modelFactory, "modelFactory").IsNull().Throw();

            Guard.WhenArgument<Payroll>(calculate, "calculate").IsNull().Throw();

            this.remunerationBillService = remunerationBillService;
            this.employeeService = employeeService;

            this.modelFactory = modelFactory;
            this.Payroll = calculate;

            this.View.GetEmployee += GetEmployee;
            this.View.CalculateRemunerationBill += CalculateRemunerationBill;
            this.View.CreateRemunerationBill += CreateRemunerationBill;
        }

        public Payroll Payroll { get; set; }

        public void GetEmployee(object sender, IEmployeeEventArgs e)
        {
            var employee = this.modelFactory.GetEmployee();
            employee.FirstName = e.FirstName;
            employee.MiddleName = e.MiddleName;
            employee.LastName = e.LastName;
            employee.PersonalId = e.PersonalId;

            this.View.Model.Employee = employee;
            this.employeeService.Create(this.View.Model.Employee);
        }

        public void CalculateRemunerationBill(object sender, IRemunerationBillEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.GrossSalary, "GrossSalary").IsLessThan(0).Throw();

            var remunerationBill = this.modelFactory.GetRemunerationBill();
            remunerationBill.CreatedDate = e.CreatedDate;
            remunerationBill.EmployeeId = this.View.Model.Employee.Id;
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
