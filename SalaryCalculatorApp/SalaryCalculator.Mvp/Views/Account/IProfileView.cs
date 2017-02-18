using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models.Account;

namespace SalaryCalculator.Mvp.Views.Account
{
    public interface IProfileView : IView<ProfileModel>
    {
        event EventHandler<EventArgs> GetUser;

        event EventHandler<EventArgs> UpdateUser;
    }
}
