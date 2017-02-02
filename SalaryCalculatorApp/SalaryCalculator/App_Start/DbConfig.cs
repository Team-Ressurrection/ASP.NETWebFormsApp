using SalaryCalculator.Data;
using SalaryCalculator.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SalaryCalculator.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalaryCalculatorDbContext, Configuration>());
            SalaryCalculatorDbContext.Create().Database.Initialize(true);
        }
    }
}