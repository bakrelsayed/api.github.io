using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IUsersRepository
    {
        void AddUser(Users user);
        IEnumerable<Users> GetUsers();
        bool DeleteUser(long userId);
        Users GetUser(long Id);
        Task<Users> Login(string UserName, string Password);
    }
}
