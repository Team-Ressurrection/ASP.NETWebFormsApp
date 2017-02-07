using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
    public class ProfilePresenter : Presenter<IProfileView>, IProfilePresenter
    {
        private readonly IUserService userService;

        public ProfilePresenter(IProfileView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument<IUserService>(userService, "userService").IsNull().Throw();

            this.userService = userService;
        }

        public User GetUser(int id)
        {
            Guard.WhenArgument<int>(id, "id").IsLessThan(0).Throw();

            return this.View.Model.User = this.userService.GetById(id);
        }
    }
}
