﻿using System;

using Ninject;

using WebFormsMvp;
using WebFormsMvp.Binder;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Factories;
using SalaryCalculator.Mvp.Models.JobContracts;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;

namespace SalaryCalculator.JobContracts
{
    [PresenterBinding(typeof(CreateLaborContractPresenter))]
    public partial class CreateLaborContract : MvpPage<CreateLaborContractModel>, ICreateLaborContractView
    {
        [Inject]
        public ISalaryCalculatorEventArgsFactory EventArgsFactory { get; set; }

        protected CreateLaborContract()
        {

        }

        [Inject]
        public CreateLaborContract(ISalaryCalculatorEventArgsFactory eventArgsFactory)
        {
            this.EventArgsFactory = eventArgsFactory;
        }

        public event EventHandler<IPaycheckEventArgs> CalculatePaycheck;

        public event EventHandler<IPaycheckEventArgs> CreatePaycheck;

        public event EventHandler<IEmployeeEventArgs> GetEmployee;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalculateWage_Click(object sender, EventArgs e)
        {
            this.FirstNameLabel.Visible = false;
            this.FirstName.Visible = false;
            this.MiddleNameLabel.Visible = false;
            this.MiddleName.Visible = false;
            this.LastNameLabel.Visible = false;
            this.LastName.Visible = false;
            this.CreatedDateLabel.Visible = false;
            this.CreatedDate.Visible = false;
            this.PersonalIdLabel.Visible = false;
            this.PersonalId.Visible = false;
            this.GrossBaseSalaryLabel.Visible = false;
            this.GrossBaseSalary.Visible = false;
            this.FixedBonusLabel.Visible = false;
            this.FixedBonus.Visible = false;
            this.NonFixedBonusLabel.Visible = false;
            this.NonFixedBonus.Visible = false;
            this.CalculateWage.Visible = false;

            this.DetailsViewPaycheck.Visible = true;

            var employeeArgs = this.EventArgsFactory.GetEmployeeEventArgs(this.FirstName.Text, this.MiddleName.Text, this.LastName.Text, this.PersonalId.Text);

            this.GetEmployee?.Invoke(this, employeeArgs);

            var args = this.EventArgsFactory.GetPaycheckEventArgs((decimal.Parse)(this.GrossBaseSalary.Text), (decimal.Parse)(this.FixedBonus.Text), (decimal.Parse)(this.NonFixedBonus.Text),DateTime.Parse(this.CreatedDate.Text));

            this.CalculatePaycheck?.Invoke(this, args);
            this.CreatePaycheck?.Invoke(this.Model.EmployeePaycheck, args);

            this.DetailsViewPaycheck.DataSource = new[] { this.Model.EmployeePaycheck };
            this.DetailsViewPaycheck.DataBind();
        }
    }
}