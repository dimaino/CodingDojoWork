using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanning.Models
{
    public class MasterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
        public DbSet<User> User {get;set;}
        public DbSet<Wedding> Wedding {get;set;}
        public DbSet<Guest> Guest {get;set;}
    }
}