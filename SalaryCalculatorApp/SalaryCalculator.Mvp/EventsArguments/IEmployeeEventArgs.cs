namespace SalaryCalculator.Mvp.EventsArguments
{
   public interface IEmployeeEventArgs
    {
        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        string PersonalId { get; set; }
    }
}
