namespace SalaryCalculator.Data.Models.Constants
{
    public static class ValidationConstants
    {
        public const int MinimumNameLength = 2;
        public const int MaximumNameLength = 20;

        public const int PersonalIdLength = 10;
        public const string PersonalIdCharacters = @"^[0-9]{10}$";

        public const int MaxSocialSecurityIncome = 2600;
    }
}
