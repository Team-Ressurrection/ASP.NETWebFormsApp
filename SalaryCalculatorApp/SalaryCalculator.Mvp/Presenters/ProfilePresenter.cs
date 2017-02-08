using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views;
using System;
using System.IO;

namespace SalaryCalculator.Mvp.Presenters
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
        }

        public User GetUser(string id)
        {
            Guard.WhenArgument<string>(id, "id").IsNullOrEmpty().Throw();

            return this.View.Model.User = this.userService.GetById(id);
        }

        public bool ValidateFile(bool isValidFile, string fileName)
        {
            var imagePath = string.Empty;
            isValidFile = false;

            var fileExtension = Path.GetExtension(fileName).ToLower();
            var allowedExtensions = new string[] { ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    isValidFile = true;
                }
            }
            return isValidFile;
        }
    }
}
