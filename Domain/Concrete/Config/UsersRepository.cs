using Domain.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        private readonly AppDbContext context;
        public UsersRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public void AddUser(Users user)
        {
            context.Users.Add(user);

            
        }

        public bool DeleteUser(long userId)
        {
            var removed = false;
            Users user = GetUser(userId);

            if (user != null)
            {
                removed = true;
                context.Users.Remove(user);
            }

            return removed;
        }

        public Users GetUser(long Id)
        {
            return context.Users.Where(u => u.Id == Id).FirstOrDefault();
            //return null;
        }

        public IEnumerable<Users> GetUsers()
        {
            return (IEnumerable<Users>)context.Users.ToListAsync();
        }
        public async Task<Users> Login(string UserName, string Password)
        {
            var CheckUser = await context.Users.Where(x => x.UserName == UserName.ToLower() && x.Password == Password).FirstOrDefaultAsync();
            return CheckUser;
        }
    }

}
