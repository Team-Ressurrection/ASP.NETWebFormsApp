using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface ICreateNonLaborContractView : IView<CreateNonLaborContractModel>
    {
        event EventHandler<RemunerationBillEventArgs> CalculateRemunerationBill;

        event EventHandler<RemunerationBillEventArgs> CreateRemunerationBill;
    }
}
