using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface IProfileView : IView<ProfileModel>
    {
        event EventHandler<EventArgs> GetUser;

        event EventHandler<EventArgs> UpdateUser;
    }
}
