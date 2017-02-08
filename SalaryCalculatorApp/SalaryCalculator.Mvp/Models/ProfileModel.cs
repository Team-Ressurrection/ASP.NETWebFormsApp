using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class ProfileModel : IProfileModel
    {
        public virtual User User { get; set; }
    }
}
