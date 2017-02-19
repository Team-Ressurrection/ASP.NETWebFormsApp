using SalaryCalculator.Mvp.Models.Settings;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SalaryCalculator.Mvp.EventsArguments;
using Ninject;
using SalaryCalculator.Factories;
using SalaryCalculator.Mvp.Factories;

namespace SalaryCalculator.Settings
{
    [PresenterBinding(typeof(SettingsUsersPresenter))]
    public partial class AllUsers : MvpPage<SettingsUsersModel>, ISettingsUsersView
    {
        public event EventHandler GetAllUsers;

        public event EventHandler<IModelIdEventArgs> DeleteModel;

        public event EventHandler<IModelIdEventArgs> UpdateModel;

        protected AllUsers()
        {

        }

        [Inject]
        public AllUsers(ISalaryCalculatorEventArgsFactory eventArgsFactory)
        {
            this.EventArgsFactory = eventArgsFactory;
        }

        [Inject]
        public ISalaryCalculatorEventArgsFactory EventArgsFactory { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SalaryCalculator.Data.Models.User> Users_GetData()
        {
            this.GetAllUsers?.Invoke(this, null);

            return this.Model.Users.AsQueryable();
        }

        public void Users_UpdateUser(string id)
        {
            this.UpdateModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }

        public void Users_DeleteUser(string id)
        {
            this.DeleteModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }
    }
}