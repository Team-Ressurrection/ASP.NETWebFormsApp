using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public class CreateNonLaborContractModel : ICreateNonLaborContractModel
    {
        public virtual RemunerationBill RemunerationBill { get; set; }
    }
}
