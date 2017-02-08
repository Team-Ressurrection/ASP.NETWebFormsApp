using WebFormsMvp;

using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
    public interface IProfilePresenter : IPresenter<IProfileView>
    {
        bool ValidateFile(bool isValidFile, string fileName);
    }
}
