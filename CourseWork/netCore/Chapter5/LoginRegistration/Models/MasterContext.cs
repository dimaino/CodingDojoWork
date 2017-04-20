using Microsoft.EntityFrameworkCore;
 
namespace LoginRegistration.Models
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
        public DbSet<User> User {get; set;}
    }
}