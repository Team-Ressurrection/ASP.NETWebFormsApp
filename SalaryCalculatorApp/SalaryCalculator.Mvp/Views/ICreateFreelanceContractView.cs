using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface ICreateFreelanceContractView : IView<CreateFreelanceContractModel>
    {
        event EventHandler<SelfEmploymentEventArgs> CalculateSelfEmployment;

        event EventHandler<SelfEmploymentEventArgs> CreateSelfEmployment;
    }
}
