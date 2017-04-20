using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User {get;set;}
        public string Wedder1_Name { get; set; }
        public string Wedder2_Name { get; set; }
        public DateTime Wedding_Date { get; set; }
        public string Wedding_Address { get; set; }
        public DateTime created_at { get; set;}
        public DateTime updated_at { get; set;}
        public List<Guest> Guests { get; set; }
        public Wedding() {
            Guests = new List<Guest>();
        }

        
    }
}