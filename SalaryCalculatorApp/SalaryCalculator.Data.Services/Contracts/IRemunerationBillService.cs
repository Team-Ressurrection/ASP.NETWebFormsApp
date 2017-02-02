using System.Linq;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Data.Services.Contracts
{
    public interface IRemunerationBillService
    {
        IQueryable<RemunerationBill> GetTop(int count);

        IQueryable<RemunerationBill> GetAll();

        RemunerationBill GetById(int id);

        void UpdateById(int id, RemunerationBill updateBill);

        void DeleteById(int id);

        void Create(RemunerationBill bill);
    }
}
