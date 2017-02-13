using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public interface ICreateFreelanceContractModel
    {
        SelfEmployment SelfEmployment { get; set; }
    }
}
