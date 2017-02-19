using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public class CreateLaborContractModel : ICreateLaborContractModel, IEmployeeModel
    {
        public virtual Employee Employee { get; set; }

        public virtual EmployeePaycheck EmployeePaycheck { get; set; }
    }
}
