using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Mvp.Factories
{
    public class SalaryCalculatorEventArgsFactory : ISalaryCalculatorEventArgsFactory
    {
        public IPaycheckEventArgs GetPaycheckEventArgs(decimal grossSalary, decimal fixedBonus, decimal nonFixedBonus)
        {
           return new PaycheckEventArgs(grossSalary, fixedBonus, nonFixedBonus);
        }

        public IRemunerationBillEventArgs GetRemunerationBillEventArgs(decimal grossSalary)
        {
            return new RemunerationBillEventArgs(grossSalary);
        }

        public ISelfEmploymentEventArgs GetSelfEmploymentEventArgs(decimal socialSecurityIncome, decimal additionalSocialSecurityIncome = 0, bool isInsuredForGDM = false)
        {
            return new SelfEmploymentEventArgs(socialSecurityIncome, additionalSocialSecurityIncome, isInsuredForGDM);
        }
    }
}
