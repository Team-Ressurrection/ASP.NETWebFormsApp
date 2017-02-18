using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.Settings;

namespace SalaryCalculator.Mvp.Views.Settings
{
   public interface ISettingsFreelanceContractsView : IView<SettingsFreelanceContractsModel>
    {
        event EventHandler<EventArgs> GetAllFreelanceContracts;

        event EventHandler<ModelIdEventArgs> DeleteModel;

        event EventHandler<ModelIdEventArgs> UpdateModel;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
