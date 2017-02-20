using System;
using System.Security.Claims;
using System.Linq;

using Ninject;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Factories;
using SalaryCalculator.Mvp.Models.Account;
using SalaryCalculator.Mvp.Presenters.Account;
using SalaryCalculator.Mvp.Views.Account;

namespace SalaryCalculator.Account
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileModel>, IProfileView
    {

        public event EventHandler<IModelIdEventArgs> GetUser;
        public event EventHandler UpdateUser;

        protected Profile()
        {

        }

        [Inject]
        public Profile(ISalaryCalculatorEventArgsFactory eventArgsFactory)
        {
            this.EventArgsFactory = eventArgsFactory;
        }

        [Inject]
        public ISalaryCalculatorEventArgsFactory EventArgsFactory { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdValue = string.Empty;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userIdValue = userIdClaim.Value;
                }
            }

            var args = this.EventArgsFactory.GetModelIdEventArgs(userIdValue);
            this.GetUser?.Invoke(this, args);

            this.DetailInfo.DataSource = new[] { this.Model.User };
            this.DetailInfo.DataBind();
            this.ImageID.ImageUrl = "../Images/" + this.Model.User.ImagePath;
        }

        protected void ButtonLoad_Click(object sender, EventArgs e)
        {
            var fullFolderPath = Server.MapPath("../Images/");

            this.FileUpload.PostedFile.SaveAs(fullFolderPath + this.FileUpload.FileName);
            this.Model.User.ImagePath = this.FileUpload.FileName;

            this.ImageID.ImageUrl = this.Model.User.ImagePath;

            this.UpdateUser?.Invoke(this.Model.User, null);
            this.ImageID.ImageUrl = "../Images/" + this.Model.User.ImagePath;

            this.FileUpload.Visible = false;
            this.ButtonLoad.Visible = false;
        }
    }
}