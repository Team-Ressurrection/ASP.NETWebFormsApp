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
    [PresenterBinding(typeof(SettingsFreelanceContractsPresenter))]
    public partial class SelfEmployment : MvpPage<SettingsFreelanceContractsModel>, ISettingsFreelanceContractsView
    {
        public event EventHandler GetAllFreelanceContracts;
        public event EventHandler<IModelIdEventArgs> DeleteModel;
        public event EventHandler<IModelIdEventArgs> UpdateModel;

        protected SelfEmployment()
        {

        }

        [Inject]
        public SelfEmployment(ISalaryCalculatorEventArgsFactory eventArgsFactory)
        {
            this.EventArgsFactory = eventArgsFactory;
        }

        [Inject]
        public ISalaryCalculatorEventArgsFactory EventArgsFactory { get; set; }

        public IQueryable<SalaryCalculator.Data.Models.SelfEmployment> FreelanceContracts_GetData()
        {
            this.GetAllFreelanceContracts?.Invoke(this, null);

            return this.Model.FreelanceContracts.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FreelanceContracts_UpdateContract(int id)
        {
            this.UpdateModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FreelanceContracts_DeleteContract(int id)
        {
            this.DeleteModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }
    }
}