using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Models
{
    public class Accounts : BaseEntity
    {
        [Key]
        public int id {get;set;}
        [ForeignKey("Users")]
        public int user_id {get;set;}
        public virtual Users Users {get;set;}
        public int Number {get;set;}
        public double Balance {get;set;}

        // ADD ACCOUNT TYPE eg. CHECKING, CD, SAVINGS
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public List<Deposits> Deposits {get;set;}
        public List<Withdrawals> Withdrawals {get;set;}
        public Accounts()
        {
            Deposits = new List<Deposits>();
            Withdrawals = new List<Withdrawals>();
        }
    }
}