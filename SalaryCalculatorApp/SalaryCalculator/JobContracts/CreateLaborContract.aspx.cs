using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaryCalculator.JobContracts
{
    public partial class CreateLaborContract : System.Web.UI.Page
    {
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
            this.GrossBaseSalaryLabel.Visible = false;
            this.GrossBaseSalary.Visible = false;
            this.FixedBonusLabel.Visible = false;
            this.FixedBonus.Visible = false;
            this.NonFixedBonusLabel.Visible = false;
            this.NonFixedBonus.Visible = false;
            this.CalculateWage.Visible = false;

            this.SaveDocument.Visible = true;
            this.Paycheck.Visible = true;
        }

        protected void SaveDocument_Click(object sender, EventArgs e)
        {
            // TODO:
        }
    }
}