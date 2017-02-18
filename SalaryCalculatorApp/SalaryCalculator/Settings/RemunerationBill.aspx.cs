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
    [PresenterBinding(typeof(SettingsNonLaborContractsPresenter))]
    public partial class RemunerationBill : MvpPage<SettingsNonLaborContractsModel>, ISettingsNonLaborContractsView
    {
        public event EventHandler GetAllNonLaborContracts;
        public event EventHandler<IModelIdEventArgs> DeleteModel;
        public event EventHandler<IModelIdEventArgs> UpdateModel;

        protected RemunerationBill()
        {

        }

        [Inject]
        public RemunerationBill(ISalaryCalculatorEventArgsFactory eventArgsFactory)
        {
            this.EventArgsFactory = eventArgsFactory;       
        }

        [Inject]
        public ISalaryCalculatorEventArgsFactory EventArgsFactory { get; set; }

        public IQueryable<SalaryCalculator.Data.Models.RemunerationBill> NonLaborContracts_GetData()
        {
            this.GetAllNonLaborContracts?.Invoke(this, null);

            return this.Model.NonLaborContracts.AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void NonLaborContracts_UpdateContract(int id)
        {
            this.UpdateModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void NonLaborContracts_DeleteContract(int id)
        {
            this.DeleteModel?.Invoke(this, this.EventArgsFactory.GetModelIdEventArgs(id));
        }
    }
}