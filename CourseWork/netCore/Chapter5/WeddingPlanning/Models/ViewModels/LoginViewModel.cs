using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanning.Models
{
    public class LoginViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress]
        public string Email {get;set;}
        [Required(ErrorMessage = "Password is a required field.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}