using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
   public interface ICreateFreelanceContractPresenter : IPresenter<ICreateFreelanceContractView>
    {
        void CalculateSelfEmployment(object sender, ISelfEmploymentEventArgs e);

        void CreateSelfEmployment(object sender, ISelfEmploymentEventArgs e);
    }
}
