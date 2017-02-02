using System;
using System.Linq;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculator.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> employees;

        public EmployeeService(IRepository<Employee> employees)
        {
            this.employees = employees;
        }

        public void Create(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("Employee cannot be null");
            }
            this.employees.Add(employee);
            this.employees.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.employees.Delete(id);
            this.employees.SaveChanges();
        }

        public IQueryable<Employee> GetAll()
        {
            return this.employees.All;
        }

        public Employee GetById(int id)
        {
            return this.employees.GetById(id);
        }

        public IQueryable<Employee> GetTop(int count)
        {
            return this.employees.All.Take(count);
        }

        public void UpdateById(int id, Employee updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
