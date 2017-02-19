using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public class CreateNonLaborContractModel : ICreateNonLaborContractModel, IEmployeeModel
    {
        public virtual RemunerationBill RemunerationBill { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
