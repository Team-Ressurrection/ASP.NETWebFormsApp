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

        protected override void Seed(SalaryCalculator.Data.SalaryCalculatorDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}