using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace SalaryCalculator.Mvp.Views.Settings
{
    public interface ISettingsUsersView : IView<SettingsUsersModel>
    {
        event EventHandler GetAllUsers;

        event EventHandler<IModelIdEventArgs> DeleteModel;

        event EventHandler<IModelIdEventArgs> UpdateModel;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
