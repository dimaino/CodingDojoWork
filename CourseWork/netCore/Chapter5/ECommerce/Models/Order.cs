using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Order : BaseEntity
    {
        [Key]
        public int id {get; set;}
        public int Quantity {get;set;}
        [ForeignKey("Customer")]
        public int customer_id {get;set;}
        public Customer Customer {get;set;}
        [ForeignKey("Product")]
        public int product_id {get;set;}
        public Product Product {get;set;}

        public Order()
        {

        }        
    }
}