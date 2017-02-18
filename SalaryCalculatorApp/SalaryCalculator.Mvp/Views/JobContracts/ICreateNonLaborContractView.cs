using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.JobContracts;

namespace SalaryCalculator.Mvp.Views.JobContracts
{
    public interface ICreateNonLaborContractView : IView<CreateNonLaborContractModel>
    {
        event EventHandler<IRemunerationBillEventArgs> CalculateRemunerationBill;

        event EventHandler<IRemunerationBillEventArgs> CreateRemunerationBill;
    }
}
