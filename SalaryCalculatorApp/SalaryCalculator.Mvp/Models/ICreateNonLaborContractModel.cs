using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public interface ICreateNonLaborContractModel
    {
        RemunerationBill RemunerationBill { get; set; }
    }
}
