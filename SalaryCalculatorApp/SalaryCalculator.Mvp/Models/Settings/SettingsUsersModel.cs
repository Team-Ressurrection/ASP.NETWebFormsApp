using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Settings
{
    public class SettingsUsersModel : ISettingsUsersModel
    {
        public virtual IEnumerable<User> Users { get; set; }
    }
}
