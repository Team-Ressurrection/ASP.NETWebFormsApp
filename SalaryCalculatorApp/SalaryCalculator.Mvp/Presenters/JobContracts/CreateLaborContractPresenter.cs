using System;
using System.Collections.Generic;

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
    public class CreateLaborContractPresenter : Presenter<ICreateLaborContractView>, ICreateLaborContractPresenter
    {
        private readonly IEmployeePaycheckService paycheckService;
        private readonly IEmployeeService employeeService;
        private readonly ISalaryCalculatorModelFactory modelFactory;

        public CreateLaborContractPresenter(ICreateLaborContractView view, IEmployeePaycheckService paycheckService,IEmployeeService employeeService,ISalaryCalculatorModelFactory modelFactory ,Payroll calculate)
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService").IsNull().Throw();

            Guard.WhenArgument<IEmployeeService>(employeeService, "employeeService").IsNull().Throw();

            Guard.WhenArgument<ISalaryCalculatorModelFactory>(modelFactory, "modelFactory").IsNull().Throw();

            Guard.WhenArgument<Payroll>(calculate, "calculate").IsNull().Throw();

            this.paycheckService = paycheckService;
            this.employeeService = employeeService;

            this.Payroll = calculate;
            this.modelFactory = modelFactory;

            this.View.GetEmployee += GetEmployee;
            this.View.CalculatePaycheck += CalculatePaycheck;
            this.View.CreatePaycheck += CreatePaycheck;
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

        public void CalculatePaycheck(object sender, IPaycheckEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.GrossFixedBonus, "GrossFixedBonus").IsLessThan(0).Throw();
            Guard.WhenArgument<decimal>(e.GrossNonFixedBonus, "GrossNonFixedBonus").IsLessThan(0).Throw();
            Guard.WhenArgument<decimal>(e.GrossSalary, "GrossSalary").IsLessThan(0).Throw();

            var paycheck = this.modelFactory.GetEmployeePaycheck();
            paycheck.CreatedDate = e.CreatedDate;
            paycheck.EmployeeId = this.View.Model.Employee.Id;
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

            paycheck.PersonalInsurance = this.Payroll.GetPersonalInsurance(paycheck.SocialSecurityIncome);

            paycheck.IncomeTax = this.Payroll.GetIncomeTax(grossSalary, paycheck.PersonalInsurance);

            paycheck.NetWage = this.Payroll.GetNetWage(grossSalary, paycheck.PersonalInsurance,paycheck.IncomeTax);

            this.View.Model.EmployeePaycheck = paycheck;
             
        }

        public void CreatePaycheck(object sender, IPaycheckEventArgs e)
        {
            Guard.WhenArgument<EmployeePaycheck>(this.View.Model.EmployeePaycheck, "EmployeePaycheck").IsNull().IsNotInstanceOfType(typeof(EmployeePaycheck)).Throw();

            this.paycheckService.Create(this.View.Model.EmployeePaycheck);
        }
    }
}
