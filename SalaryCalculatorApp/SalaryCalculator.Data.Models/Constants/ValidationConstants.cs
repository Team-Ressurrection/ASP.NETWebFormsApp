using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
