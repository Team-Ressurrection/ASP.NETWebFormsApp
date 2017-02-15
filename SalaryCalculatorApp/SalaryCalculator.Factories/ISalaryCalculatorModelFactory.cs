using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Factories
{
    public interface ISalaryCalculatorModelFactory
    {
        User GetUser();

        Employee GetEmployee();

        EmployeePaycheck GetEmployeePaycheck();

        RemunerationBill GetRemunerationBill();

        SelfEmployment GetSelfEmployment();
    }
}
