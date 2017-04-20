using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Customer : BaseEntity
    {
        [Key]
        public int id {get; set;}
        public string Customer_Name {get; set;}
        public List<Order> Orders {get;set;}
        public Customer()
        {
            Orders = new List<Order>();
        }        
    }
}