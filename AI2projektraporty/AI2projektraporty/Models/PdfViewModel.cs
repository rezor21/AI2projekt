using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AI2projektraporty.Models
{
    public class PdfViewModel
    {
        public Report Report {get; set;}
        public string Date { get; set; }
        public double Sum { get; set; }
       public ICollection<Transaction> Transactions { get; set; }
        public ICollection<string> Titles { get; set; }
        public ICollection<double> Amounts { get; set; }
    }
}
