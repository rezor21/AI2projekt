using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AI2projektraporty.Models
{
    public enum Type
    {
        Daily, Monthly, Yearly
    }
    public class Report
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public Type Type { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ReportTransaction> ReportTransaction { get; set; }



    }
}
