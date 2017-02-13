using WebFormsMvp;

using SalaryCalculator.Mvp.Models;
using System;

namespace SalaryCalculator.Mvp.Views
{
    public interface IAdministratorSettingsView : IView<AdministratorSettingsModel>
    {
        event EventHandler<EventArgs> GetAllLaborContracts;

        event EventHandler<EventArgs> GetAllNonLaborContracts;

        event EventHandler<EventArgs> GetAllFreelanceContracts;
    }
}
