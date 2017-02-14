using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Data.Models
{
    public class Employee
    {
        private ICollection<RemunerationBill> remunerationBills;
        private ICollection<EmployeePaycheck> employeePaychecks;
        private ICollection<SelfEmployment> selfEmployments;

        public Employee()
        {
            this.remunerationBills = new HashSet<RemunerationBill>();

            this.employeePaychecks = new HashSet<EmployeePaycheck>();

            this.selfEmployments = new HashSet<SelfEmployment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinimumNameLength)]
        [MaxLength(ValidationConstants.MaximumNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinimumNameLength)]
        [MaxLength(ValidationConstants.MaximumNameLength)]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinimumNameLength)]
        [MaxLength(ValidationConstants.MaximumNameLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(ValidationConstants.PersonalIdLength)]
        [RegularExpression(ValidationConstants.PersonalIdCharacters)]
        public string PersonalId { get; set; }

        public virtual ICollection<RemunerationBill> RemunerationBills
        {
            get
            {
                return this.remunerationBills;
            }

            set
            {
                this.remunerationBills = value;
            }
        }

        public virtual ICollection<EmployeePaycheck> EmployeePaychecks
        {
            get
            {
                return this.employeePaychecks;
            }

            set
            {
                this.employeePaychecks = value;
            }
        }

        public virtual ICollection<SelfEmployment> SelfEmployments
        {
            get
            {
                return this.selfEmployments;
            }

            set
            {
                this.selfEmployments = value;
            }
        }
    }
}
