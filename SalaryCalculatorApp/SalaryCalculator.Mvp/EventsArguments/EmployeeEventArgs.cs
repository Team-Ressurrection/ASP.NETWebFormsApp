using System;

namespace SalaryCalculator.Mvp.EventsArguments
{
    public class EmployeeEventArgs : EventArgs, IEmployeeEventArgs
    {
        public EmployeeEventArgs(string firstName, string middleName, string lastName, string personalId)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.PersonalId = personalId;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PersonalId { get; set; }
    }
}
