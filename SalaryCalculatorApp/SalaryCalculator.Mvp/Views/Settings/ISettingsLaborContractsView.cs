using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.Settings;

namespace SalaryCalculator.Mvp.Views.Settings
{
    public interface ISettingsLaborContractsView : IView<SettingsLaborContractsModel>
    {
        event EventHandler<EventArgs> GetAllLaborContracts;

        event EventHandler<ModelIdEventArgs> DeleteModel;

        event EventHandler<ModelIdEventArgs> UpdateModel;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
