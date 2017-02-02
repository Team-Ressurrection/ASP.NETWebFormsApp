using System;
using System.Linq;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculator.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public void Create(User user)
        {
            this.users.Add(user);
            this.users.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.users.Delete(id);
            this.users.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All;
        }

        public User GetById(int id)
        {
            return this.users.GetById(id);
        }

        public IQueryable<User> GetTop(int count)
        {
            return this.users.All.Take(count);
        }

        public void UpdateById(int id, User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
