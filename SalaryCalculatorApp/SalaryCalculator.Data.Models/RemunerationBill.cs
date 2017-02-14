using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SalaryCalculator.Utilities.Constants;

namespace SalaryCalculator.Data.Models
{
    public class RemunerationBill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Range(0, ValidationConstants.MaxSocialSecurityIncome)]
        public decimal SocialSecurityIncome { get; set; }

        [Required]
        public decimal GrossSalary { get; set; }

        [Required]
        public decimal NetWage { get; set; }

        [Required]
        public decimal PersonalInsurance { get; set; }

        [Required]
        public decimal IncomeTax { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

    }
}