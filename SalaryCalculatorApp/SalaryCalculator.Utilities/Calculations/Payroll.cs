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

        public decimal GetIncomeTax(decimal grossSalary, decimal personalInsurance)
        {
            return (grossSalary - personalInsurance) * ValidationConstants.IncomeTaxPercent;
        }

        public decimal GetNetWage(decimal grossSalary, decimal personalInsurance, decimal incomeTax)
        {
            return grossSalary - personalInsurance - incomeTax;
        }

        public decimal GetPersonalInsurance(decimal salary)
        {
            return salary * ValidationConstants.PersonalInsurancePercent;
        }

        public bool CheckMaxSocialSecurityIncome(decimal parameter)
        {
            var isMaximum = parameter.CompareTo(ValidationConstants.MaxSocialSecurityIncome) >= 0;

            return isMaximum;
        }
    }
}
