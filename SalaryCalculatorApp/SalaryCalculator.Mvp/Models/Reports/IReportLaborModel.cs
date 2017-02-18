using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Reports
{
    public interface IReportLaborModel
    {
        IEnumerable<EmployeePaycheck> LaborContracts { get; set; }
    }
}
