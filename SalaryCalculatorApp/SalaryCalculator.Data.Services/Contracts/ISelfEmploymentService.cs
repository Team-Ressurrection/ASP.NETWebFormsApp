using System.Linq;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Data.Services.Contracts
{
    public interface ISelfEmploymentService
    {
        IQueryable<SelfEmployment> GetTop(int count);

        IQueryable<SelfEmployment> GetAll();

        SelfEmployment GetById(int id);

        void UpdateById(int id, SelfEmployment updateBill);

        void DeleteById(int id);

        void Create(SelfEmployment bill);
    }
}
