using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Account
{
    public class ProfileModel : IProfileModel
    {
        public virtual User User { get; set; }
    }
}
