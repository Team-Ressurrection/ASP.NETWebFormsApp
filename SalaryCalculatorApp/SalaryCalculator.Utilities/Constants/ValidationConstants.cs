namespace SalaryCalculator.Utilities.Constants
{
    public static class ValidationConstants
    {
        public const int MinimumNameLength = 2;
        public const int MaximumNameLength = 20;

        public const int PersonalIdLength = 10;
        public const string PersonalIdCharacters = @"^[0-9]{10}$";

        public const int MaxSocialSecurityIncome = 2600;

        public const decimal PersonalInsurancePercent = 0.129m;
        public const decimal IncomeTaxPercent = 0.1m;
    }
}
