using System;

using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Mvp.Factories
{
    public interface ISalaryCalculatorEventArgsFactory
    {
        IPaycheckEventArgs GetPaycheckEventArgs(decimal grossSalary, decimal fixedBonus, decimal nonFixedBonus, DateTime createdDate);

        IRemunerationBillEventArgs GetRemunerationBillEventArgs(decimal grossSalary, DateTime createdDate);

        ISelfEmploymentEventArgs GetSelfEmploymentEventArgs(decimal socialSecurityIncome, DateTime createdDate,decimal additionalSocialSecurityIncome = 0, bool isInsuredForGDM = false);

        IModelIdEventArgs GetModelIdEventArgs(int id);

        IModelIdEventArgs GetModelIdEventArgs(string id);

        IEmployeeEventArgs GetEmployeeEventArgs(string firstName, string middleName, string lastName, string personalId);
    }
}
