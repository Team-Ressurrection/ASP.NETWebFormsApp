using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class CreateFreelanceContractModel : ICreateFreelanceContractModel
    {
        public virtual SelfEmployment SelfEmployment { get; set; }
    }
}
