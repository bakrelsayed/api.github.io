using Domain.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Config
{
    public class ListOfCalculationsRepository : IListOfCalculationsRepository
    {
        private readonly AppDbContext context;
        public ListOfCalculationsRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }
        public void AddData(MainTable objectData)
        {
            
            if(objectData.Id == 0)
            {
                var obj = new MainTable();
                obj.HeaderColor = objectData.HeaderColor;
                obj.DataColor = objectData.DataColor;
                obj.CellColor = objectData.CellColor;
                obj.FooterColor = objectData.FooterColor;
                context.MainTable.Add(obj);
                context.SaveChanges();
                objectData.Id = obj.Id;
            }
            else
            {
                var CheckMainTableData = context.MainTable.Where(x => x.Id == objectData.Id).FirstOrDefault();
                CheckMainTableData.HeaderColor = objectData.HeaderColor;
                CheckMainTableData.DataColor = objectData.DataColor;
                CheckMainTableData.CellColor = objectData.CellColor;
                CheckMainTableData.FooterColor = objectData.FooterColor;
            }
           
            foreach (var item in objectData.ListOfCalculations)
            {
                if (item.Id != 0)
                {
                    var OldData = context.ListOfCalculations.Where(x => x.Id == item.Id).FirstOrDefault();
                    OldData.ListDate = item.ListDate;
                    OldData.Organization = item.Organization;
                    OldData.TotalCost = item.TotalCost;
                    OldData.BakrPortion = item.BakrPortion;
                    OldData.YomePortion = item.YomePortion;
                    OldData.BakrDebit = item.BakrDebit;
                    OldData.YomeDebit = item.YomeDebit;
                    OldData.BakrCredit = item.BakrCredit;
                    OldData.YomeCredit = item.YomeCredit;
                }
                if (item.Id == 0)
                {
                    item.MainTableId = objectData.Id;
                    context.ListOfCalculations.Add(item);
                }
            }
        }

        public bool DeleteRow(long RowId)
        {
            var removed = false;
            ListOfCalculations row = GetRow(RowId);

            if (row != null)
            {
                removed = true;
                context.ListOfCalculations.Remove(row);
            }

            return removed;
        }

        public ListOfCalculations GetRow(long Id)
        {
            return context.ListOfCalculations.Where(u => u.Id == Id).FirstOrDefault();
            
        }

        public MainTable GetFullLists()
        {
            var data = context.MainTable.ToList().Select(p => new MainTable {
                Id = p.Id,
                HeaderColor = p.HeaderColor,
                DataColor = p.DataColor,
                CellColor = p.CellColor,
                FooterColor = p.FooterColor,
                ListOfCalculations = context.ListOfCalculations.Where(x => x.MainTableId == p.Id).ToList().Select(n => new ListOfCalculations
                {
                    Id = n.Id,
                    MainTableId = n.MainTableId,
                    ListDate = n.ListDate,
                    Organization = n.Organization,
                    TotalCost = n.TotalCost,
                    BakrPortion = n.BakrPortion,
                    YomePortion = n.YomePortion,
                    BakrDebit = n.BakrDebit,
                    YomeDebit = n.YomeDebit,
                    BakrCredit = n.BakrCredit,
                    YomeCredit = n.YomeCredit,



                }).ToList(),

            }).FirstOrDefault();
            return data;
        }
    }
}
