﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SalaryCalculator.Data.Models.Constants;

namespace SalaryCalculator.Data.Models
{
    public class SelfEmployment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Range(0, ValidationConstants.MaxSocialSecurityIncome)]
        public decimal SocialSecurityIncome { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal NetWage { get; set; }

        [Required]
        public decimal PersonalInsurance { get; set; }

        public decimal IncomeTax { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
