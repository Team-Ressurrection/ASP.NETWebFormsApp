using System.Collections.Generic;
using System.Linq;

using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Utilities.Calculations
{
    public class Payroll
    {
        public decimal GetGrossSalary(IEnumerable<decimal> parameters)
        {
            return parameters.Sum();
        }

        public decimal GetPersonalInsurance(decimal salary, decimal personalInsurancePercent)
        {
            return salary * personalInsurancePercent;
        }

        public bool CheckMaxSocialSecurityIncome(decimal parameter)
        {
            var isMaximum = parameter.CompareTo(ValidationConstants.MaxSocialSecurityIncome) >= 0;

            return isMaximum;
        }
    }
}
