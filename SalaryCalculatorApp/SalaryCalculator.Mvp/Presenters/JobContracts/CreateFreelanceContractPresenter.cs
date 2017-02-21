using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.JobContracts;
using SalaryCalculator.Utilities.Constants;
using SalaryCalculator.Utilities.Calculations;

namespace SalaryCalculator.Mvp.Presenters.JobContracts
{
    public class CreateFreelanceContractPresenter : Presenter<ICreateFreelanceContractView>, ICreateFreelanceContractPresenter
    {
        private readonly ISelfEmploymentService selfEmploymentService;
        private readonly IEmployeeService employeeService;
        private readonly ISalaryCalculatorModelFactory modelFactory;

        public CreateFreelanceContractPresenter(ICreateFreelanceContractView view, ISelfEmploymentService selfEmploymentService, IEmployeeService employeeService,ISalaryCalculatorModelFactory modelFactory,Payroll calculate)
            : base(view)
        {
            Guard.WhenArgument<ISelfEmploymentService>(selfEmploymentService, "selfEmploymentService").IsNull().Throw();

            Guard.WhenArgument<IEmployeeService>(employeeService, "employeeService").IsNull().Throw();

            Guard.WhenArgument<ISalaryCalculatorModelFactory>(modelFactory, "modelFactory").IsNull().Throw();

            Guard.WhenArgument<Payroll>(calculate, "calculate").IsNull().Throw();

            this.selfEmploymentService = selfEmploymentService;
            this.employeeService = employeeService;

            this.modelFactory = modelFactory;
            this.Payroll = calculate;

            this.View.GetEmployee += GetEmployee;
            this.View.CalculateSelfEmployment += CalculateSelfEmployment;
            this.View.CreateSelfEmployment += CreateSelfEmployment;
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

        public void CalculateSelfEmployment(object sender, ISelfEmploymentEventArgs e)
        {
            Guard.WhenArgument<decimal>(e.SocialSecurityIncome, "SocialSecurityIncome").IsLessThan(0).Throw();

            var selfEmployment = this.modelFactory.GetSelfEmployment();
            selfEmployment.CreatedDate = e.CreatedDate;
            selfEmployment.EmployeeId = this.View.Model.Employee.Id;
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
