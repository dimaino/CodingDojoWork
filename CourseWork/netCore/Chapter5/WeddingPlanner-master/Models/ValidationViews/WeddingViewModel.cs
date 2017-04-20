using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class WeddingViewModel : BaseEntity
    {
        [Required(ErrorMessage = "First Wedder's Name field is required.")]
        public string Wedder1_Name { get; set; }
        [Required(ErrorMessage = "Second Wedder's Name field is required.")]
        public string Wedder2_Name { get; set; }
        [Display(Name = "Wedding Date")]
        [Required(ErrorMessage = "Wedding Date is a required field.")]
        [CheckFutureDate]
        [DataType(DataType.Date)]
        public DateTime? Wedding_Date { get; set; }
        [Required(ErrorMessage = "The Wedding Address field is required.")]
        public string Wedding_Address { get; set; }
    }
}