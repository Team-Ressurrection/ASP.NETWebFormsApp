using System;

using Ninject;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Factories;
using SalaryCalculator.Mvp.Models.JobContracts;
using SalaryCalculator.Mvp.Presenters.JobContracts;
using SalaryCalculator.Mvp.Views.JobContracts;

namespace SalaryCalculator.JobContracts
{
    [PresenterBinding(typeof(CreateFreelanceContractPresenter))]
    public partial class CreateFreelanceContract : MvpPage<CreateFreelanceContractModel>, ICreateFreelanceContractView
    {
        protected CreateFreelanceContract()
        {

        }

        [Inject]
        public CreateFreelanceContract(ISalaryCalculatorEventArgsFactory eventArgsFactory)
        {
            this.eventArgsFactory = eventArgsFactory;
        }

        [Inject]
        public ISalaryCalculatorEventArgsFactory eventArgsFactory { get; set; }

        public event EventHandler<ISelfEmploymentEventArgs> CalculateSelfEmployment;
        public event EventHandler<ISelfEmploymentEventArgs> CreateSelfEmployment;
        public event EventHandler<IEmployeeEventArgs> GetEmployee;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalculateSocialSecurityContributions_Click(object sender, EventArgs e)
        {
            this.FirstNameLabel.Visible = false;
            this.FirstName.Visible = false;
            this.MiddleNameLabel.Visible = false;
            this.MiddleName.Visible = false;
            this.LastNameLabel.Visible = false;
            this.LastName.Visible = false;
            this.PersonalIdLabel.Visible = false;
            this.PersonalId.Visible = false;
            this.CreatedDateLabel.Visible = false;
            this.CreatedDate.Visible = false;
            this.SocialSecurityIncomeLabel.Visible = false;
            this.SocialSecurityIncome.Visible = false;
            this.CalculateSocialSecurityContributions.Visible = false;


            var employeeArgs = this.eventArgsFactory.GetEmployeeEventArgs(this.FirstName.Text, this.MiddleName.Text, this.LastName.Text, this.PersonalId.Text);
            this.GetEmployee?.Invoke(this, employeeArgs);

            var args = this.eventArgsFactory.GetSelfEmploymentEventArgs((decimal.Parse)(this.SocialSecurityIncome.Text), 0, false);

            this.CalculateSelfEmployment?.Invoke(this, args);
            this.CreateSelfEmployment?.Invoke(this.Model.SelfEmployment, args);


            this.DetailsViewSelfEmploymentContributions.DataSource = new[] { this.Model.SelfEmployment };
            this.DetailsViewSelfEmploymentContributions.DataBind();

            this.DetailsViewSelfEmploymentContributions.Visible = true;
        }
    }
}