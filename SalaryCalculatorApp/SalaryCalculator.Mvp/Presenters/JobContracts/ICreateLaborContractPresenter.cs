using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.JobContracts;

namespace SalaryCalculator.Mvp.Presenters.JobContracts
{
   public interface ICreateLaborContractPresenter : IPresenter<ICreateLaborContractView>
    {
        void CalculatePaycheck(object sender, IPaycheckEventArgs e);

        void CreatePaycheck(object sender, IPaycheckEventArgs e);
    }
}
