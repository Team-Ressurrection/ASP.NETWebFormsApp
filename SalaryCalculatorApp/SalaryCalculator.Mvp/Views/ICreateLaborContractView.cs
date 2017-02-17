using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface ICreateLaborContractView : IView<CreateLaborContractModel>
    {
        event EventHandler<IPaycheckEventArgs> CalculatePaycheck;

        event EventHandler<IPaycheckEventArgs> CreatePaycheck;
    }
}
