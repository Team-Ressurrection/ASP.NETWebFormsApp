using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Factories
{
    public class SalaryCalculatorModelFactory : ISalaryCalculatorModelFactory
    {
        public Employee GetEmployee()
        {
            return new Employee();
        }

        public EmployeePaycheck GetEmployeePaycheck()
        {
            return new EmployeePaycheck();
        }

        public RemunerationBill GetRemunerationBill()
        {
            return new RemunerationBill();
        }

        public SelfEmployment GetSelfEmployment()
        {
            return new SelfEmployment();
        }

        public User GetUser()
        {
            return new User();
        }
    }
}
