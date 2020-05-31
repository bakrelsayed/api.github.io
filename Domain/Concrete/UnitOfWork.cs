using Domain.Abstract;
using Domain.Concrete.Config;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        //public UnitOfWork(AppDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        public UnitOfWork(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
            Users = new UsersRepository(dbContext);
            MainTable = new Repository<MainTable>(dbContext);
            ListOfCalculations = new ListOfCalculationsRepository(dbContext);
        }
        public IUsersRepository Users { get; private set; }

        public IRepository<MainTable> MainTable { get; private set; }
        public IListOfCalculationsRepository ListOfCalculations { get; private set; }


    }
}
