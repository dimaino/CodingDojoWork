using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanning.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int id {get;set;}
        public string Groom_Name {get;set;}
        public string Bride_Name {get;set;}
        public DateTime Wedding_Date {get;set;}

        public string Address {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public int user_id {get;set;}
        public List<Guest> WeddingGuest {get;set;}
        public Wedding()
        {
            WeddingGuest = new List<Guest>();
        }
    }
}