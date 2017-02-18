using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.JobContracts;

namespace SalaryCalculator.Mvp.Views.JobContracts
{
    public interface ICreateLaborContractView : IView<CreateLaborContractModel>
    {
        event EventHandler<IPaycheckEventArgs> CalculatePaycheck;

        event EventHandler<IPaycheckEventArgs> CreatePaycheck;
    }
}
