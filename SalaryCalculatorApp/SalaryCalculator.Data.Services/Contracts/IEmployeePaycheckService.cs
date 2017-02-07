using System.Linq;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Data.Services.Contracts
{
    public interface IEmployeePaycheckService
    {
        IQueryable<EmployeePaycheck> GetTop(int count);

        IQueryable<EmployeePaycheck> GetAll();

        EmployeePaycheck GetById(int id);

        void UpdateById(int id, EmployeePaycheck updateBill);

        void DeleteById(int id);

        void Create(EmployeePaycheck bill);
    }
}
