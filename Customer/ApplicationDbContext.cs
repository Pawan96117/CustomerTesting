using Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<Clients> clients { get; set; }
    }
}
