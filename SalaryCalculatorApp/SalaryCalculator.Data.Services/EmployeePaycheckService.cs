using System.Linq;

using Bytes2you.Validation;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculator.Data.Services
{
    public class EmployeePaycheckService : IEmployeePaycheckService
    {
        private IRepository<EmployeePaycheck> employeePaychecks;

        public EmployeePaycheckService(IRepository<EmployeePaycheck> employeePaychecks)
        {
            this.employeePaychecks = employeePaychecks;
        }

        public void Create(EmployeePaycheck paycheck)
        {
            Guard.WhenArgument(paycheck, "paycheck").IsNull().Throw();

            this.employeePaychecks.Add(paycheck);
            this.employeePaychecks.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.employeePaychecks.Delete(id);
            this.employeePaychecks.SaveChanges();
        }

        public IQueryable<EmployeePaycheck> GetAll()
        {
            return this.employeePaychecks.All;
        }

        public EmployeePaycheck GetById(int id)
        {
            return this.employeePaychecks.GetById(id);
        }

        public IQueryable<EmployeePaycheck> GetTop(int count)
        {
            return this.employeePaychecks.All.Take(count);
        }

        public void UpdateById(int id, EmployeePaycheck updatePaycheck)
        {
            var paycheckToUpdate = this.employeePaychecks.GetById(id);

            paycheckToUpdate.EmployeeId = updatePaycheck.EmployeeId;

            this.employeePaychecks.SaveChanges();
        }
    }
}
