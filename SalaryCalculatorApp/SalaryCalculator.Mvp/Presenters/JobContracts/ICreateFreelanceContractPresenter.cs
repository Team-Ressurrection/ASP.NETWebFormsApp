using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.JobContracts;

namespace SalaryCalculator.Mvp.Presenters.JobContracts
{
   public interface ICreateFreelanceContractPresenter : IPresenter<ICreateFreelanceContractView>
    {
        void CalculateSelfEmployment(object sender, ISelfEmploymentEventArgs e);

        void CreateSelfEmployment(object sender, ISelfEmploymentEventArgs e);

        void GetEmployee(object sender, IEmployeeEventArgs e);
    }
}
