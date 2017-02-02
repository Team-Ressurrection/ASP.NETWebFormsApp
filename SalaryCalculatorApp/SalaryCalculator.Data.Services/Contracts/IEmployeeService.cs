using System.Linq;

using SalaryCalculator.Data.Models;

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
