using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class ReportNonLaborModel : IReportNonLaborModel
    {
        public IEnumerable<RemunerationBill> NonLaborContracts { get; set; }
    }
}
