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
    [PresenterBinding(typeof(SettingsLaborContractsPresenter))]
    public partial class EmployeePaycheck : MvpPage<SettingsLaborContractsModel>, ISettingsLaborContractsView
    {
        public event EventHandler GetAllLaborContracts;
        public event EventHandler<IModelIdEventArgs> UpdateModel;
        public event EventHandler<IModelIdEventArgs> DeleteModel;

        protected EmployeePaycheck()
        {

        }

        [Inject]
        public EmployeePaycheck(ISalaryCalculatorEventArgsFactory eventArgsFactory)
        {
            this.EventArgsFactory = eventArgsFactory;
        }

        [Inject]
        public ISalaryCalculatorEventArgsFactory EventArgsFactory { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<SalaryCalculator.Data.Models.EmployeePaycheck> AllLaborContracts_GetData()
        {
            this.GetAllLaborContracts?.Invoke(this, null);

            return this.Model.LaborContracts.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LaborContracts_UpdateContract(int id)
        {
            this.UpdateModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void LaborContracts_DeleteContract(int id)
        {
            this.DeleteModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }
    }
}