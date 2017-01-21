using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Data.Services.Contracts
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetTop(int count);

        IQueryable<Employee> GetAll();

        Employee GetById(int id);

        void UpdateById(int id, Employee updateUser);

        void DeleteById(int id);

        void Create(Employee User);
    }
}
