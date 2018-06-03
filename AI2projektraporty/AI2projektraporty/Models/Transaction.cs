using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AI2projektraporty.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public virtual ICollection<ReportTransaction> TransactionReport { get; set; }
    }
}
