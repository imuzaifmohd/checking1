using customerDemoWebApiPart2_withEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace customerDemoWebApiPart2_withEntityFramework.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
