using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public interface ICreateNonLaborContractModel
    {
        RemunerationBill RemunerationBill { get; set; }
    }
}
