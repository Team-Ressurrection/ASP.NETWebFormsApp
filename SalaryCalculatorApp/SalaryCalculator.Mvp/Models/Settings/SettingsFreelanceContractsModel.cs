using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Settings
{
    public class SettingsFreelanceContractsModel : ISettingsFreelanceContractsModel
    {
        public virtual IEnumerable<SelfEmployment> FreelanceContracts { get; set; }

        public virtual SelfEmployment SelfEmployment { get; set; }
    }
}
