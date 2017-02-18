using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Settings
{
    public class SettingsNonLaborContractsModel : ISettingsNonLaborContractsModel
    {
        public virtual IEnumerable<RemunerationBill> NonLaborContracts { get; set; }

        public virtual RemunerationBill RemunerationBill { get; set; }
    }
}
