using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface ICreateLaborContractView : IView<CreateLaborContractModel>
    {
        event EventHandler<EventArgs> CreatePaycheck;
    }
}
