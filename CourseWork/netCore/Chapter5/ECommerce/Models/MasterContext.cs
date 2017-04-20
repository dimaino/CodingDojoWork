using Microsoft.EntityFrameworkCore;
 
namespace ECommerce.Models
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
        public DbSet<Customer> Customer {get; set;}
        public DbSet<Product> Product {get; set;}
        public DbSet<Order> Order {get; set;}
    }
}