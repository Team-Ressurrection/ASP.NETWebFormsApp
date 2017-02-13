using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class CreateNonLaborContractModel : ICreateNonLaborContractModel
    {
        public virtual RemunerationBill RemunerationBill { get; set; }
    }
}
