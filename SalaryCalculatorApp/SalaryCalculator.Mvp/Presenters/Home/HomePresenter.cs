using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views.Home;

namespace SalaryCalculator.Mvp.Presenters.Home
{
    public class HomePresenter : Presenter<IHomeView>, IHomePresenter
    {
        private readonly IUserService userService;

        public HomePresenter(IHomeView view, IUserService userService) 
            : base(view)
        {
            Guard.WhenArgument<IUserService>(userService, "userService").IsNull().Throw();

            this.userService = userService;

            this.View.GetLatestUsers += View_GetLatestUsers;
        }

        private void View_GetLatestUsers(object sender, EventArgs e)
        {
            this.View.Model.Users = this.userService.GetTop(3);
        }
    }
}
