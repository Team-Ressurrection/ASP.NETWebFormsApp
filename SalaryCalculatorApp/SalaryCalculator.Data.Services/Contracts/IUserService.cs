using System;
using System.Linq;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Data.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetTop(int count);

        IQueryable<User> GetAll();

        User GetById(string id);

        void UpdateById(string id, User updateUser);

        void DeleteById(string id);

        void Create(User User);
    }
}
