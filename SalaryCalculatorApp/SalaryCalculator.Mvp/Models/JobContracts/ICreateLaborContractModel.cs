using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public interface ICreateLaborContractModel
    {
        EmployeePaycheck EmployeePaycheck { get; set; }
    }
}
