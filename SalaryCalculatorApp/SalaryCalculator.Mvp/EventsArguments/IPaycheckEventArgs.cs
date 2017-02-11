namespace SalaryCalculator.Mvp.EventsArguments
{
    public interface IPaycheckEventArgs
    {
        decimal GrossSalary { get; set; }

        decimal GrossFixedBonus { get; set; }

        decimal GrossNonFixedBonus { get; set; }
    }
}
