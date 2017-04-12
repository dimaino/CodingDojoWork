using System.ComponentModel.DataAnnotations;
using System;

namespace LoginAndReg.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "A First Name is required.")]
        [MinLength(2, ErrorMessage = "First Name must contain at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name may only contain letters.")]
        public string firstName {get;set;}
        [Required(ErrorMessage = "A Last Name is required.")]
        [MinLength(2, ErrorMessage = "Last Name must contain at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name may only contain letters.")]
        public string lastName {get;set;}
        [Required(ErrorMessage = "An Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid email such as example@example.com")]
        public string email {get;set;}
        [Required(ErrorMessage = "A Password is required.")]
        [MinLength(8, ErrorMessage = "Password must contain at least 2 characters.")]
        public string password {get;set;}
        [Required(ErrorMessage = "A Password Confirmation is required")]
        [Compare(nameof(password), ErrorMessage = "Password and Password Confirmation must match.")]
        public string passwordConfirmation {get;set;} 
    }
}