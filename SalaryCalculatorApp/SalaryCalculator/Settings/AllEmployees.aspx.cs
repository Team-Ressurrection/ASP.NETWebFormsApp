using System;
using System.Linq;

using Ninject;

using WebFormsMvp;
using WebFormsMvp.Web;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Factories;
using SalaryCalculator.Mvp.Models.Settings;
using SalaryCalculator.Mvp.Presenters.Settings;
using SalaryCalculator.Mvp.Views.Settings;

namespace SalaryCalculator.Settings
{
    [PresenterBinding(typeof(SettingsEmployeesPresenter))]
    public partial class AllEmployees : MvpPage<SettingsEmployeesModel>, ISettingsEmployeesView
    {
        public event EventHandler GetAllEmployees;
        public event EventHandler<IModelIdEventArgs> DeleteModel;
        public event EventHandler<IModelIdEventArgs> UpdateModel;

        protected AllEmployees()
        {

        }

        [Inject]
        public AllEmployees(ISalaryCalculatorEventArgsFactory eventArgsFactory)
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
        public IQueryable<SalaryCalculator.Data.Models.Employee> Employees_GetData()
        {
            this.GetAllEmployees?.Invoke(this, null);

            return this.Model.Employees.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void Employees_UpdateEmployee(int id)
        {
            this.UpdateModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void Employees_DeleteEmployee(int id)
        {
            this.DeleteModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }
    }
}