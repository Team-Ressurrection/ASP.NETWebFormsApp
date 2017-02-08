using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public interface ICreateLaborContractModel
    {
        EmployeePaycheck EmployeePaycheck { get; set; }
    }
}
