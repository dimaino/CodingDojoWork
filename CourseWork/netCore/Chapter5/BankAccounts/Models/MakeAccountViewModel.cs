using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class MakeAccountViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Balance is a required field.")]
        public string Balance {get;set;}
    }
}