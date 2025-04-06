using LoanManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<AvailableMoney> AvailableMoney { get; set; }
    }
}