using SalaryCalculator.Mvp.Models.Home;
using SalaryCalculator.Mvp.Presenters.Home;
using SalaryCalculator.Mvp.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SalaryCalculator
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class _Default : MvpPage<HomeModel>, IHomeView
    {
        public event EventHandler GetLatestUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetLatestUsers?.Invoke(this, null);

            this.LatestUsersGridView.DataSource = this.Model.Users.ToList();
            this.LatestUsersGridView.DataBind();
        }
    }
}