using System;
using System.IO;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.Account;

namespace SalaryCalculator.Mvp.Presenters.Account
{
    public class ProfilePresenter : Presenter<IProfileView>, IProfilePresenter
    {
        private const string DefaultFolderPath = "~/Images/";
        private readonly IUserService userService;

        public ProfilePresenter(IProfileView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument<IUserService>(userService, "userService").IsNull().Throw();

            this.userService = userService;

            this.View.GetUser += GetUser;
            this.View.UpdateUser += UpdateUser;
        }

        public void UpdateUser(object sender, EventArgs e)
        {
            var imagePath = string.Empty;

            var fileExtension = Path.GetExtension(this.View.Model.User.ImagePath).ToLower();
            var allowedExtensions = new string[] { ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension.EndsWith(allowedExtensions[i]))
                {
                    this.userService.UpdateById(sender.ToString(), sender as User);
                }
            }
        }

        public void GetUser(object sender, IModelIdEventArgs e)
        {
            Guard.WhenArgument<IModelIdEventArgs>(e, "e").IsNull().Throw();

            this.View.Model.User = this.userService.GetById(e.UserId);
        }
    }
}
