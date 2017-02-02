using System.Linq;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculator.Data.Services
{
    public class RemunerationBillService : IRemunerationBillService
    {
        private IRepository<RemunerationBill> remunerationBills;

        public RemunerationBillService(IRepository<RemunerationBill> remunerationBills)
        {
            this.remunerationBills = remunerationBills;
        }

        public void Create(RemunerationBill bill)
        {
            this.remunerationBills.Add(bill);
            this.remunerationBills.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.remunerationBills.Delete(id);
            this.remunerationBills.SaveChanges();
        }

        public IQueryable<RemunerationBill> GetAll()
        {
            return this.remunerationBills.All;
        }

        public RemunerationBill GetById(int id)
        {
            return this.remunerationBills.GetById(id);
        }

        public IQueryable<RemunerationBill> GetTop(int count)
        {
            return this.remunerationBills.All.Take(count);
        }

        public void UpdateById(int id, RemunerationBill updateBill)
        {
            var billToUpdate = this.remunerationBills.GetById(id);

            billToUpdate.EmployeeId = updateBill.EmployeeId;

            this.remunerationBills.SaveChanges();
        }
    }
}
