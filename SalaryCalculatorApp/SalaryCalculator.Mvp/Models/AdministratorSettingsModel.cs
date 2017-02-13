using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class AdministratorSettingsModel : IAdministratorSettingsModel
    {
        public IEnumerable<SelfEmployment> FreelanceContracts { get; set; }

        public IEnumerable<EmployeePaycheck> LaborContracts { get; set; }

        public IEnumerable<RemunerationBill> NonLaborContracts { get; set; }
    }
}