using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class ReportLaborModel : IReportLaborModel
    {
        public IEnumerable<EmployeePaycheck> LaborContracts { get; set; }
    }
}
