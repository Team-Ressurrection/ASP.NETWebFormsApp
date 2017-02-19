using System;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public class ModelIdEventArgs : EventArgs,IModelIdEventArgs
    {
        public ModelIdEventArgs(int id)
        {
            this.Id = id;
        }

        public ModelIdEventArgs(string userId)
        {
            this.UserId = userId;
        }

        public int Id { get; set; }

        public string UserId { get; set; }
    }
}
