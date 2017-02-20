using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Reports
{
    public class ReportNonLaborModel : IReportNonLaborModel
    {
        public virtual IEnumerable<RemunerationBill> NonLaborContracts { get; set; }
    }
}
