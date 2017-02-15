using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class AdministratorSettingsModel : IAdministratorSettingsModel
    {
        public virtual IEnumerable<SelfEmployment> FreelanceContracts { get; set; }

        public virtual IEnumerable<EmployeePaycheck> LaborContracts { get; set; }

        public virtual IEnumerable<RemunerationBill> NonLaborContracts { get; set; }
    }
}