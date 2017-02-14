using System;

using WebFormsMvp;

namespace SalaryCalculator.Factories
{
    public interface ISalaryCalculatorPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
