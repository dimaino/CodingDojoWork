using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanning.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int id {get;set;}
        public string First_Name {get;set;}
        public string Last_Name {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public List<Guest> UserGuest {get;set;}
        public List<Wedding> Weddings {get;set;}
        public User()
        {
            UserGuest = new List<Guest>();
            Weddings = new List<Wedding>();
        }
    }
}