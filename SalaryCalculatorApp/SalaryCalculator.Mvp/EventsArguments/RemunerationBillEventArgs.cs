using System;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public class RemunerationBillEventArgs : IRemunerationBillEventArgs
    {
        public RemunerationBillEventArgs(decimal grossSalary, DateTime createdDate)
        {
            this.GrossSalary = grossSalary;
            this.CreatedDate = createdDate;
        }

        public decimal GrossSalary { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
