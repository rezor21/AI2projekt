using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AI2projektraporty.Models
{
    public class ReportTransaction
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public virtual Report Report { get; set; }

        public int TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
