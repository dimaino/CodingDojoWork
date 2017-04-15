using System;
using System.ComponentModel.DataAnnotations;
namespace lostInTheWoods.Models
{
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        public string Trail_Name { get; set; }
 
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
 
        [Required]
        [Range(0, int.MaxValue)]
        public double Trail_Length { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double Elevation_Change {get; set;}
        [Required]
        [RegularExpression(@"^-?[0-9]{1,3}\.{1}[0-9]{0,6}$")]
        public double Latitude {get;set;}

        [Required]
        [RegularExpression(@"^-?[0-9]{1,3}\.{1}[0-9]{0,6}$")]
        public double Longitude {get;set;}

        public DateTime created_at {get;set;}

        public DateTime updated_at {get;set;}
    }
}