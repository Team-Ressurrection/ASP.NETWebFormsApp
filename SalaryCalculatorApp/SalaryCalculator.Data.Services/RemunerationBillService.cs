using SalaryCalculator.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Contracts;

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
