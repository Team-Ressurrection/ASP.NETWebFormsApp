using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Settings
{
    public class SettingsLaborContractsModel : ISettingsLaborContractsModel
    {
        public virtual IEnumerable<EmployeePaycheck> LaborContracts { get; set; }

        public virtual EmployeePaycheck EmployeePaycheck { get; set; }
    }
}