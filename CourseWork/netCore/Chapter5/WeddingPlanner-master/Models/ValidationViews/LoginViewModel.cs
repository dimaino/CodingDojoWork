using System;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class LoginViewModel : BaseEntity
    {
        private static WeddingPlannerContext _context;
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress]
        public string Email {get;set;}
        [Required(ErrorMessage = "Password is a required field.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}