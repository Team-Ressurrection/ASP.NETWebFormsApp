using System.Linq;

using Bytes2you.Validation;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculator.Data.Services
{
    public class SelfEmploymentService : ISelfEmploymentService
    {
        private IRepository<SelfEmployment> selfEmployments;

        public SelfEmploymentService(IRepository<SelfEmployment> selfEmployments)
        {
            Guard.WhenArgument(selfEmployments, "SelfEmployment").IsNull().Throw();

            this.selfEmployments = selfEmployments;
        }

        public void Create(SelfEmployment selfEmpl)
        {
            Guard.WhenArgument(selfEmpl, "selfEmpl").IsNull().Throw();

            this.selfEmployments.Add(selfEmpl);
            this.selfEmployments.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Guard.WhenArgument<int>(id, "id").IsLessThanOrEqual<int>(0).Throw();

            this.selfEmployments.Delete(id);
            this.selfEmployments.SaveChanges();
        }

        public IQueryable<SelfEmployment> GetAll()
        {
            return this.selfEmployments.All;
        }

        public SelfEmployment GetById(int id)
        {
            Guard.WhenArgument<int>(id, "id").IsLessThanOrEqual<int>(0).Throw();

            return this.selfEmployments.GetById(id);
        }

        public IQueryable<SelfEmployment> GetTop(int count)
        {
            return this.selfEmployments.All.Take(count);
        }

        public void UpdateById(int id, SelfEmployment updatePaycheck)
        {
            this.selfEmployments.Update(updatePaycheck);
            this.selfEmployments.SaveChanges();
        }
    }
}
