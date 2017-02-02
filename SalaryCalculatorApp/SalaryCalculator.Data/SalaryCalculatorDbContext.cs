using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

using SalaryCalculator.Data.Contracts;
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

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<RemunerationBill> RemunerationBills { get; set; }
    }
}
