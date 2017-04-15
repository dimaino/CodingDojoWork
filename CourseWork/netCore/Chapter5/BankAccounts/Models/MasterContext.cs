using Microsoft.EntityFrameworkCore;
 
namespace BankAccounts.Models
{
    public class MasterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
        public DbSet<Users> Users {get;set;}
        public DbSet<Accounts> Accounts {get;set;}

        public DbSet<Deposits> Deposits {get;set;}
        public DbSet<Withdrawals> Withdrawals {get;set;}
    }
}