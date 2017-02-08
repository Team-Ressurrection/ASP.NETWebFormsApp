using System;

using WebFormsMvp;

using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
    public interface IProfilePresenter : IPresenter<IProfileView>
    {
        void GetUser(object sender, EventArgs e);

        void UpdateUser(object sender, EventArgs e);
    }
}
