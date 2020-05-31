using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IListOfCalculationsRepository
    {
        void AddData(MainTable objectData);
        MainTable GetFullLists();
        bool DeleteRow(long userId);
        ListOfCalculations GetRow(long Id);
    }
}
