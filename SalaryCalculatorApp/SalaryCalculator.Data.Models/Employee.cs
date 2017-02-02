using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using SalaryCalculator.Data.Models.Constants;

namespace SalaryCalculator.Data.Models
{
    public class Employee
    {
        private ICollection<RemunerationBill> remunerationBills;

        public Employee()
        {
            this.remunerationBills = new HashSet<RemunerationBill>();
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
    }
}
