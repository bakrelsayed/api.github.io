using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class MainTable
    {
        public MainTable()
        {
            ListOfCalculations = new List<ListOfCalculations>();
        }
        public int Id { get; set; }
        public string HeaderColor { get; set; }
        public string DataColor { get; set; }
        public string CellColor { get; set; }
        public string FooterColor { get; set; }

        public virtual List<ListOfCalculations> ListOfCalculations { get; set; }
    }
}
