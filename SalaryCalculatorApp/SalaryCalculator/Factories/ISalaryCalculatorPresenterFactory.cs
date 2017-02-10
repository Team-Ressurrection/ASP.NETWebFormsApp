using System;

using WebFormsMvp;

namespace SalaryCalculator.Factory
{
    public interface ISalaryCalculatorPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
