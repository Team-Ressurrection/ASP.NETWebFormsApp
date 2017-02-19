using System;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public interface IModelIdEventArgs
    {
        int Id { get; set; }

        string UserId { get; set; }
    }
}
