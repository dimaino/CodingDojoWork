using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User : BaseEntity
    {
        [Required]
        [MinLength(4)]
        public string firstName {get;set;} // 4 chars at least
        [Required]
        [MinLength(4)]
        public string lastName {get;set;}
        [Required]
        [Range(1,140)]
        public int age {get;set;} // must be a positive number
        [Required]
        [EmailAddress]
        public string email {get;set;} // valid email format
        [Required]
        [MinLength(8)]
        public string password {get;set;} // 8 chars long
    }
}