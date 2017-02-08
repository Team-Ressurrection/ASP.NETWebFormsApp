using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.Models;
using SalaryCalculator.Mvp.Presenters;
using SalaryCalculator.Mvp.Views;
using System.Web;

namespace SalaryCalculator.Account
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileModel>, IProfileView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonLoad_Click(object sender, EventArgs e)
        {
            var isValid = false;
            var path = Server.MapPath("../Images/");
            //if (this.FileUpload.HasFile)
            //{
            //    isValid = ValidateFile()
            //}
            this.FileUpload.PostedFile.SaveAs(path + this.FileUpload.FileName);
            this.Model.User.ImagePath = path + this.FileUpload.FileName;
        }
    }
}