using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class MondeyViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Amount is a required field.")]
        [Range(0,100000000000)]
        public string amount {get;set;}
    }
}