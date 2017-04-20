using Microsoft.EntityFrameworkCore;
 
namespace UserDashboard.Models
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
        public DbSet<User> User {get; set;}
    }
}