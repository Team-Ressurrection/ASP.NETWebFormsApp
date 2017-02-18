using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Mvp.Factories
{
    public interface ISalaryCalculatorEventArgsFactory
    {
        IPaycheckEventArgs GetPaycheckEventArgs(decimal grossSalary, decimal fixedBonus, decimal nonFixedBonus);

        IRemunerationBillEventArgs GetRemunerationBillEventArgs(decimal grossSalary);

        ISelfEmploymentEventArgs GetSelfEmploymentEventArgs(decimal socialSecurityIncome, decimal additionalSocialSecurityIncome = 0, bool isInsuredForGDM = false);

        IModelIdEventArgs GetModelIdEventArgs(int id);
    }
}
