using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Data.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetTop(int count);

        IQueryable<User> GetAll();

        User GetById(int id);

        void UpdateById(int id, User updateUser);

        void DeleteById(int id);

        void Create(User User);
    }
}
