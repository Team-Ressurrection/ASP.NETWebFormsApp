using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public class CreateFreelanceContractModel : ICreateFreelanceContractModel
    {
        public virtual SelfEmployment SelfEmployment { get; set; }
    }
}
