using SalaryCalculator.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Data
{
    public class SalaryCalculatorDbContext : IdentityDbContext<User>, ISalaryCalculatorDbContext
    {
        public SalaryCalculatorDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SalaryCalculatorDbContext Create()
        {
            return new SalaryCalculatorDbContext();
        }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<RemunerationBill> RemunerationBills { get; set; }
    }
}
