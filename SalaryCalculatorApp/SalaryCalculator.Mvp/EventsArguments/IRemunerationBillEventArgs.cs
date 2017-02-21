using System;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public interface IRemunerationBillEventArgs
    {
        decimal GrossSalary { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
