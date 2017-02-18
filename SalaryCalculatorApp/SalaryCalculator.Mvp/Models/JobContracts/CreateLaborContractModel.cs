using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public class CreateLaborContractModel : ICreateLaborContractModel
    {
        public virtual EmployeePaycheck EmployeePaycheck { get; set; }
    }
}
