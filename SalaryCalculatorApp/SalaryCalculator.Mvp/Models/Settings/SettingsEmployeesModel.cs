using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Settings
{
    public class SettingsEmployeesModel : ISettingsEmployeesModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
