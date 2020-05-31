using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<MainTable> MainTable { get; }
        IListOfCalculationsRepository ListOfCalculations { get; }
        IUsersRepository Users { get; }
    }
}
