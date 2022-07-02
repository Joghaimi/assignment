using assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Employees> Employees { set;get;}
        public DbSet<Units> Unit { set;get;}
    }
}
