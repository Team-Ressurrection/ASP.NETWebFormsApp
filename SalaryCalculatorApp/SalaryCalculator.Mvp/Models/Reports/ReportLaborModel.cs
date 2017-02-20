using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Reports
{
    public class ReportLaborModel : IReportLaborModel
    {
        public virtual IEnumerable<EmployeePaycheck> LaborContracts { get; set; }
    }
}
