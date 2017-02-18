using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.Models.Account;
using SalaryCalculator.Mvp.Presenters.Account;
using SalaryCalculator.Mvp.Views.Account;

namespace SalaryCalculator.Account
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileModel>, IProfileView
    {
        public event EventHandler<EventArgs> GetUser;
        public event EventHandler<EventArgs> UpdateUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var userEventArgs = new EventArgs();

            this.GetUser?.Invoke("a1b91097-d765-48c5-8592-d9c9ca0e15aa", userEventArgs);
            this.ImageID.ImageUrl = "../Images/" + this.Model.User.ImagePath;
        }

        protected void ButtonLoad_Click(object sender, EventArgs e)
        {
            var fullFolderPath = Server.MapPath("../Images/");

            this.FileUpload.PostedFile.SaveAs(fullFolderPath + this.FileUpload.FileName);
            this.Model.User.ImagePath = this.FileUpload.FileName;

            this.ImageID.ImageUrl = this.Model.User.ImagePath;

            this.UpdateUser?.Invoke(this.Model.User, e);
            this.ImageID.ImageUrl = "../Images/" + this.Model.User.ImagePath;

            this.FileUpload.Visible = false;
            this.ButtonLoad.Visible = false;
        }
    }
}