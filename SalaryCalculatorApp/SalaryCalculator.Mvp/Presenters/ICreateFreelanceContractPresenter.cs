using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
   public interface ICreateFreelanceContractPresenter : IPresenter<ICreateFreelanceContractView>
    {
        void CalculateSelfEmployment(object sender, SelfEmploymentEventArgs e);

        void CreateSelfEmployment(object sender, SelfEmploymentEventArgs e);
    }
}
