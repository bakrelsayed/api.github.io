using Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    //public class Repository<T> : IRepository where AppDbContext : DbContext
    public class Repository<T> : IRepository <T> where T : class
    {
        protected readonly AppDbContext dbContext;

        public Repository(AppDbContext context)
        {
            dbContext = context;
        }
        public Repository() { }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindAll<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();

        }

        public async Task<T> FindById<T>(long id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);

        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }
    }
}
