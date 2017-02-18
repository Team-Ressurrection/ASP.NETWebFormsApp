using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models;

namespace SalaryCalculator.Mvp.Views
{
    public interface IAdministratorSettingsView : IView<AdministratorSettingsModel>
    {
        event EventHandler<EventArgs> GetAllLaborContracts;

        event EventHandler<EventArgs> GetAllNonLaborContracts;

        event EventHandler<EventArgs> GetAllFreelanceContracts;

        event EventHandler<ModelIdEventArgs> UpdatePaycheck;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
