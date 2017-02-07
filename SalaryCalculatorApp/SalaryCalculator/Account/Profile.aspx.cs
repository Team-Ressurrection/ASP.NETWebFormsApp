using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Account
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileModel>, IProfileView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}