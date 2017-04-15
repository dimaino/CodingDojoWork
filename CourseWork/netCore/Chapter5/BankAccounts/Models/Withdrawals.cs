using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Models
{
    public class Withdrawals : BaseEntity
    {
        [Key]
        public int id {get;set;}
        [ForeignKey("Users")]
        public int user_id {get;set;}
        public Users Users {get;set;}
        [ForeignKey("Accounts")]
        public int account_id {get;set;}
        public Accounts Accounts {get;set;}
        public double amount {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
}