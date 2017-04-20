using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int id {get; set;}
        public string Product_Name {get; set;}
        public string Description {get;set;}
        public string Image_Url {get;set;}
        public int Quantity {get;set;}
        public List<Order> Orders {get;set;}
        public Product()
        {
            Orders = new List<Order>();
        }        
    }
}