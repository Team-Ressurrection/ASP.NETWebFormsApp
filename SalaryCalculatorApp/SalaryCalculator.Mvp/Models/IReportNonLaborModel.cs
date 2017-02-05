using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public interface IReportNonLaborModel
    {
        IEnumerable<RemunerationBill> NonLaborContracts { get; set; }
    }
}
