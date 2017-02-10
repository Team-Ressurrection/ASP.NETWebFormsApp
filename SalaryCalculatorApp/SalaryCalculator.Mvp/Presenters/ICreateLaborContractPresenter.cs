using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
   public interface ICreateLaborContractPresenter : IPresenter<ICreateLaborContractView>
    {
        void CalculatePaycheck(object sender, PaycheckEventArgs e);

        void CreatePaycheck(object sender, PaycheckEventArgs e);
    }
}
