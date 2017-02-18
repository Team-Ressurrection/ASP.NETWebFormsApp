using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.JobContracts;

namespace SalaryCalculator.Mvp.Views.JobContracts
{
    public interface ICreateFreelanceContractView : IView<CreateFreelanceContractModel>
    {
        event EventHandler<ISelfEmploymentEventArgs> CalculateSelfEmployment;

        event EventHandler<ISelfEmploymentEventArgs> CreateSelfEmployment;
    }
}
