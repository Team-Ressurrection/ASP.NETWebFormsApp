using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Settings
{
    public interface ISettingsUsersModel
    {
        IEnumerable<User> Users { get; set; }
    }
}
