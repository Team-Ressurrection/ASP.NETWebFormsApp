using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.JobContracts;

namespace SalaryCalculator.Mvp.Presenters.JobContracts
{
   public interface ICreateNonLaborContractPresenter : IPresenter<ICreateNonLaborContractView>
    {
        void CalculateRemunerationBill(object sender, IRemunerationBillEventArgs e);

        void CreateRemunerationBill(object sender, IRemunerationBillEventArgs e);

        void GetEmployee(object sender, IEmployeeEventArgs e);
    }
}
