using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Users : BaseEntity
    {
        [Key]
        public int id {get;set;}
        public string First_Name {get;set;}
        public string Last_Name {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        //public string Password_Confirmation {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public List<Accounts> Accounts {get;set;}
        public List<Deposits> Deposits {get;set;}
        public List<Withdrawals> Withdrawals {get;set;}

        public Users()
        {
            Accounts = new List<Accounts>();
            Deposits = new List<Deposits>();
            Withdrawals = new List<Withdrawals>();
        }
    }
}