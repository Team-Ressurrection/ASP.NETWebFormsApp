﻿using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.JobContracts
{
    [PresenterBinding(typeof(CreateNonLaborContractPresenter))]
    public partial class CreateNonLaborContract : MvpPage<CreateNonLaborContractModel>, ICreateNonLaborContractView
    {
        public event EventHandler<RemunerationBillEventArgs> CalculateRemunerationBill;

        public event EventHandler<RemunerationBillEventArgs> CreateRemunerationBill;

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
            this.BirthDateLabel.Visible = false;
            this.BirthDate.Visible = false;
            this.ContractValueLabel.Visible = false;
            this.ContractValue.Visible = false;
            this.CalculateWage.Visible = false;

            var args = new RemunerationBillEventArgs(decimal.Parse(this.ContractValue.Text));
            this.CalculateRemunerationBill?.Invoke(this, args);
            this.CreateRemunerationBill?.Invoke(this.Model.RemunerationBill, args);

            this.DetailsViewRemunerationBill.DataSource = new[] { this.Model.RemunerationBill };
            this.DetailsViewRemunerationBill.DataBind();

            this.SaveDocument.Visible = true;
            this.SmetkaIzplateniSumi.Visible = true;
        }

        protected void SaveDocument_Click(object sender, EventArgs e)
        {
            // TODO:
        }
    }
}