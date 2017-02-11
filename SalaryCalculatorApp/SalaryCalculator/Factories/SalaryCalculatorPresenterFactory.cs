using System;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace SalaryCalculator.Factory
{
    public class SalaryCalculatorPresenterFactory : IPresenterFactory
    {
        private readonly ISalaryCalculatorPresenterFactory factory;

        public SalaryCalculatorPresenterFactory(ISalaryCalculatorPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}