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
            Guard.WhenArgument(employeePaychecks, "EmployeePaycheck").IsNull().Throw();

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
            Guard.WhenArgument<int>(id, "id").IsLessThanOrEqual<int>(0).Throw();

            this.employeePaychecks.Delete(id);
            this.employeePaychecks.SaveChanges();
        }

        public IQueryable<EmployeePaycheck> GetAll()
        {
            return this.employeePaychecks.All;
        }

        public EmployeePaycheck GetById(int id)
        {
            Guard.WhenArgument<int>(id, "id").IsLessThanOrEqual<int>(0).Throw();

            return this.employeePaychecks.GetById(id);
        }

        public IQueryable<EmployeePaycheck> GetTop(int count)
        {
            return this.employeePaychecks.All.Take(count);
        }

        public void UpdateById(int id, EmployeePaycheck updatePaycheck)
        {
            this.employeePaychecks.Update(updatePaycheck);
            this.employeePaychecks.SaveChanges();
        }
    }
}
