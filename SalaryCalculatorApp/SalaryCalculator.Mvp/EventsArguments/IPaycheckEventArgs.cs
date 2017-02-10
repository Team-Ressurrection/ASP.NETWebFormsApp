using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public interface IPaycheckEventArgs
    {
        decimal GrossSalary { get; set; }

        decimal GrossFixedBonus { get; set; }

        decimal GrossNonFixedBonus { get; set; }
    }
}
