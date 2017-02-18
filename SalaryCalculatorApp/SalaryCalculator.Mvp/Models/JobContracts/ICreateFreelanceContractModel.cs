using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public interface ICreateFreelanceContractModel
    {
        SelfEmployment SelfEmployment { get; set; }
    }
}
