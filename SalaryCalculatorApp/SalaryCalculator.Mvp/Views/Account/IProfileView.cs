using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models.Account;
using SalaryCalculator.Mvp.EventsArguments;

namespace SalaryCalculator.Mvp.Views.Account
{
    public interface IProfileView : IView<ProfileModel>
    {
        event EventHandler<IModelIdEventArgs> GetUser;

        event EventHandler UpdateUser;
    }
}
