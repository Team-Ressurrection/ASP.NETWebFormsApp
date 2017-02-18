using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.Settings;

namespace SalaryCalculator.Mvp.Views.Settings
{
   public interface ISettingsNonLaborContractsView : IView<SettingsNonLaborContractsModel>
    {
        event EventHandler GetAllNonLaborContracts;

        event EventHandler<IModelIdEventArgs> DeleteModel;

        event EventHandler<IModelIdEventArgs> UpdateModel;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
