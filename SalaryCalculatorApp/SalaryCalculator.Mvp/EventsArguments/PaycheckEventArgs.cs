using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public class PaycheckEventArgs : IPaycheckEventArgs
    {
        public PaycheckEventArgs(decimal grossSalary, decimal fixedBonus, decimal nonFixedBonus)
        {
            this.GrossSalary = grossSalary;
            this.GrossFixedBonus = fixedBonus;
            this.GrossNonFixedBonus = nonFixedBonus;
        }

        public decimal GrossFixedBonus { get; set; }

        public decimal GrossNonFixedBonus { get; set; }

        public decimal GrossSalary { get; set; }
    }
}
