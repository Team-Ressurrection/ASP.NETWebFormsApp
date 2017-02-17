using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
   public interface ICreateNonLaborContractPresenter : IPresenter<ICreateNonLaborContractView>
    {
        void CalculateRemunerationBill(object sender, IRemunerationBillEventArgs e);

        void CreateRemunerationBill(object sender, IRemunerationBillEventArgs e);
    }
}
