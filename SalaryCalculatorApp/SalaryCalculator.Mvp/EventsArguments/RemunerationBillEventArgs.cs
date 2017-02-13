namespace SalaryCalculator.Mvp.EventsArguments
{
    public class RemunerationBillEventArgs : IRemunerationBillEventArgs
    {
        public RemunerationBillEventArgs(decimal grossSalary)
        {
            this.GrossSalary = grossSalary;
        }

        public decimal GrossSalary { get; set; }
    }
}
