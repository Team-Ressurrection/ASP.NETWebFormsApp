using System;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public class PaycheckEventArgs : IPaycheckEventArgs
    {
        public PaycheckEventArgs(decimal grossSalary, decimal fixedBonus, decimal nonFixedBonus, DateTime createdDate)
        {
            this.GrossSalary = grossSalary;
            this.GrossFixedBonus = fixedBonus;
            this.GrossNonFixedBonus = nonFixedBonus;
            this.CreatedDate = createdDate;
        }

        public DateTime CreatedDate { get; set; }

        public decimal GrossFixedBonus { get; set; }

        public decimal GrossNonFixedBonus { get; set; }

        public decimal GrossSalary { get; set; }
    }
}
