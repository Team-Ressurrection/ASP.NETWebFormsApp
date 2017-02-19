using System;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public class ModelIdEventArgs : EventArgs,IModelIdEventArgs
    {
        public ModelIdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
