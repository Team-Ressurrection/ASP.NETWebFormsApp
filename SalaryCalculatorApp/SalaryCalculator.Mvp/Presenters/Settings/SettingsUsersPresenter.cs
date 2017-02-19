using Bytes2you.Validation;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SalaryCalculator.Mvp.Presenters.Settings
{
    public class SettingsUsersPresenter : Presenter<ISettingsUsersView>, ISettingsUsersPresenter
    {
        private readonly IUserService userService;

        public SettingsUsersPresenter(ISettingsUsersView view, IUserService userService) 
            : base(view)
        {
            Guard.WhenArgument<IUserService>(userService, "userService")
                             .IsNull()
                             .Throw();

            this.userService = userService;
            this.View.GetAllUsers += View_GetAllUsers;
            this.View.UpdateModel += View_UpdateUser;
            this.View.DeleteModel += View_DeleteUser;
        }

        private void View_DeleteUser(object sender, IModelIdEventArgs e)
        {
            this.userService.DeleteById(e.UserId);
        }

        private void View_UpdateUser(object sender, IModelIdEventArgs e)
        {
            User user = this.userService.GetById(e.UserId);

            if (user == null)
            {
                this.View.ModelState.AddModelError("", string.Format("User with id {0} was not found", e.UserId));
                return;
            }
            this.View.TryUpdateModel(user);
            if (this.View.ModelState.IsValid)
            {
                this.userService.UpdateById(e.UserId, user);
            }
        }

        private void View_GetAllUsers(object sender, EventArgs e)
        {
            this.View.Model.Users = this.userService.GetAll();
        }
    }
}
