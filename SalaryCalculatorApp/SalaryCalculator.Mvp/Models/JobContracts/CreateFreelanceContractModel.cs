using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public class CreateFreelanceContractModel : ICreateFreelanceContractModel, IEmployeeModel
    {
        public virtual SelfEmployment SelfEmployment { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
