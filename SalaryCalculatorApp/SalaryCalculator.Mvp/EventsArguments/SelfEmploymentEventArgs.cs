namespace SalaryCalculator.Mvp.EventsArguments
{
    public class SelfEmploymentEventArgs : ISelfEmploymentEventArgs
    {
        public SelfEmploymentEventArgs(decimal socialSecurityIncome, decimal additionalSocialSecurityIncome = 0, bool isInsuredForGDM= false)
        {
            this.SocialSecurityIncome = socialSecurityIncome;
            this.AdditionalSocialSecurityIncome = additionalSocialSecurityIncome;
            this.IsInsuredForGeneralDiseaseAndMaternity = isInsuredForGDM;
        }

        public decimal SocialSecurityIncome { get; set; }

        public decimal AdditionalSocialSecurityIncome { get; set; }

        public bool IsInsuredForGeneralDiseaseAndMaternity { get; set; }
    }
}
