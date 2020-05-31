using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class ListOfCalculations
    {
        public ListOfCalculations()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("MainTable")]
        public int MainTableId { get; set; }
        public virtual MainTable MainTable { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ListDate { get; set; }

        public string Organization { get; set; }

        public double TotalCost { get; set; }

        public double BakrPortion { get; set; }
        public double YomePortion { get; set; }
        public double BakrDebit { get; set; }
        public double YomeDebit { get; set; }
        public double BakrCredit { get; set; }
        public double YomeCredit { get; set; }

    }
}
