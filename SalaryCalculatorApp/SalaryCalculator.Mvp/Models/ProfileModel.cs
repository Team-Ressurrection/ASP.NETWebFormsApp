using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class ProfileModel : IProfileModel
    {
        public virtual User User { get; set; }
    }
}
