using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SalaryCalculator.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SalaryCalculatorDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SalaryCalculatorDbContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }

            var seed = new SeedData();

            seed.Employees.ToList().ForEach(x => context.Employees.Add(x));

            seed.RemunerationBills.ToList().ForEach(x => context.RemunerationBills.Add(x));

            context.SaveChanges();
        }
    }
}
