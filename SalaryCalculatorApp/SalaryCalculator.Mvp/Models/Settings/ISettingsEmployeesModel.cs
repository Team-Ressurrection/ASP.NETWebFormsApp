using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Settings
{
    public interface ISettingsEmployeesModel
    {
        IEnumerable<Employee> Employees { get; set; }
    }
}
