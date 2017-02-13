using System;
using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Data.Migrations
{
    public class SeedData
    {
        public SeedData()
        {
            this.Employees = GetEmployees();
            this.RemunerationBills = GetRemunerationBills();
            this.EmployeePaychecks = GetEmployeePaychecks();
            this.SelfEmployments = GetSelfEmployments();
        }

        

        public IEnumerable<SelfEmployment> SelfEmployments { get; set; }

        public IEnumerable<EmployeePaycheck> EmployeePaychecks { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<RemunerationBill> RemunerationBills { get; set; }

        public IEnumerable<EmployeePaycheck> GetEmployeePaychecks()
        {
            var paychecks = new List<EmployeePaycheck>();

            for (int i = 1; i < 27; i++)
            {
                int day = i + 1;
                decimal grossSalary = 600 + i + 10;
                decimal netWage = 440 + i + 2;
                decimal incomeTax = 26 + i;
                decimal socialSecurity = 600 * 0.75m;
                decimal personalInsurance = 96.32m + i + 1;
                decimal fixedBonus = 100m;
                decimal nonFixedBonus = 50m;
                paychecks.Add(new EmployeePaycheck()
                {
                    CreatedDate = new DateTime(2017, 02, day),
                    EmployeeId = 1,
                    GrossSalary = grossSalary,
                    NetWage = netWage,
                    IncomeTax = incomeTax,
                    SocialSecurityIncome = socialSecurity,
                    PersonalInsurance = 98.55m,
                    GrossFixedBonus = fixedBonus * 0.8m* i,
                    GrossNonFixedBonus = nonFixedBonus * 0.75m * i
                });
            }
            return paychecks;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            var firstNames = new string[] { "Alexander", "Georgi", "Stanislav", "Elena", "Violeta", "Krasimir", "Valeria" };
            var families = new string[] { "Alexandrov", "Georgiev", "Stanislavski", "Ivanova", "Parvanova", "Krasimirov", "Stoykov" };

            for (int i = 0; i < 15; i++)
            {
                employees.Add(new Employee()
                {
                    FirstName = firstNames[i % 7],
                    MiddleName = families[i % 7],
                    LastName = families[i % 7],
                    PersonalId = "8010124560",
                    Id = i + 1,
                });
            }

            return employees;
        }

        public IEnumerable<RemunerationBill> GetRemunerationBills()
        {
            var bills = new List<RemunerationBill>();

            for (int i = 1; i < 31; i++)
            {
                int day = i + 1;
                decimal grossSalary = 600 + i + 10;
                decimal netWage = 440 + i + 2;
                decimal incomeTax = 26 + i;
                decimal socialSecurity = 600 * 0.75m;
                decimal personalInsurance = 96.32m + i + 1;
                bills.Add(new RemunerationBill()
                {
                    CreatedDate = new DateTime(2017, 01, day),
                    EmployeeId = 1,
                    GrossSalary = grossSalary,
                    NetWage = netWage,
                    IncomeTax = incomeTax,
                    SocialSecurityIncome = socialSecurity,
                    PersonalInsurance = 98.55m,
                });
            }
            return bills;
        }

        public IEnumerable<SelfEmployment> GetSelfEmployments()
        {
            var selfEmpl = new List<SelfEmployment>();

            for (int i = 1; i < 31; i++)
            {
                int day = i + 1;
                decimal socialSecurity = 600;
                decimal personalInsurance = 96.32m + i + 1;
                selfEmpl.Add(new SelfEmployment()
                {
                    CreatedDate = new DateTime(2017, 01, day),
                    EmployeeId = 1,
                    SocialSecurityIncome = socialSecurity,
                    PersonalInsurance = 98.55m,
                });
            }
            return selfEmpl;
        }
    }
}
