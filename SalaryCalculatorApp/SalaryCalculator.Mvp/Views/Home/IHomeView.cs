using SalaryCalculator.Mvp.Models.Home;
using System;
using WebFormsMvp;

namespace SalaryCalculator.Mvp.Views.Home
{
    public interface IHomeView : IView<HomeModel>
    {
        event EventHandler GetLatestUsers;
    }
}
