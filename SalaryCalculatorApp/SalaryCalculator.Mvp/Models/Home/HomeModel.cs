using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Home
{
    public class HomeModel : IHomeModel
    {
        public virtual IEnumerable<User> Users { get; set; }
    }
}
