using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public interface IReportLaborModel
    {
        IEnumerable<EmployeePaycheck> LaborContracts { get; set; }
    }
}
