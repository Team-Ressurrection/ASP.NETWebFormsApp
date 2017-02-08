using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
   public interface ICreateLaborContractPresenter : IPresenter<ICreateLaborContractView>
    {
        void CreatePaycheck(object sender, EventArgs e);
    }
}
