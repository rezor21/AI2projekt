using Microsoft.EntityFrameworkCore;
using AI2projektraporty.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AI2projektraporty.Data
{
    public class AI2Context : IdentityDbContext
    {
        public AI2Context(DbContextOptions<AI2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<ReportTransaction> ReportTransaction { get; set; }
    }
}
