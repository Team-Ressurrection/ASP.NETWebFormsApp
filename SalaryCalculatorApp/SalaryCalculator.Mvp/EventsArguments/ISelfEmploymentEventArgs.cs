namespace SalaryCalculator.Mvp.EventsArguments
{
    public interface ISelfEmploymentEventArgs
    {
        decimal SocialSecurityIncome { get; set; }

        decimal AdditionalSocialSecurityIncome { get; set; }

        bool IsInsuredForGeneralDiseaseAndMaternity { get; set; }
    }
}
