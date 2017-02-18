namespace SalaryCalculator.Mvp.EventsArguments
{
    public class ModelIdEventArgs : IModelIdEventArgs
    {
        public ModelIdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
