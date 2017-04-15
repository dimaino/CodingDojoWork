using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class ReviewViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Reviewer_Name {get;set;}

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Restaurant_Name {get;set;}

        [Required]
        [MinLength(10)]
        public string Review {get;set;}

        [Required]
        public DateTime Date_Visited {get;set;}

        [Required]
        [Range(1,5)]
        public int Stars {get;set;}
    }
}