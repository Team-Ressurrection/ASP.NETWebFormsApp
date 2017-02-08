using SalaryCalculator.Mvp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SalaryCalculator.Mvp.Views
{
    public interface IProfileView : IView<ProfileModel>
    {
        event EventHandler<EventArgs> GetUser;

        event EventHandler<EventArgs> UpdateUser;
    }
}
