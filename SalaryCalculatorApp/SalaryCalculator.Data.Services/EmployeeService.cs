using System;
using System.Linq;

using Bytes2you.Validation;

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
            Guard.WhenArgument(employees, "Employees").IsNull().Throw();

            this.employees = employees;
        }

        public void Create(Employee employee)
        {
            Guard.WhenArgument(employee, "employee").IsNull().Throw();

            this.employees.Add(employee);
            this.employees.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Guard.WhenArgument<int>(id, "id").IsLessThanOrEqual<int>(0).Throw();

            this.employees.Delete(id);
            this.employees.SaveChanges();
        }

        public IQueryable<Employee> GetAll()
        {
            return this.employees.All;
        }

        public Employee GetById(int id)
        {
            Guard.WhenArgument<int>(id, "id").IsLessThanOrEqual<int>(0).Throw();

            return this.employees.GetById(id);
        }

        public IQueryable<Employee> GetTop(int count)
        {
            return this.employees.All.Take(count);
        }

        public void UpdateById(int id, Employee updateUser)
        {
            this.employees.Update(updateUser);
            this.employees.SaveChanges();
        }
    }
}
