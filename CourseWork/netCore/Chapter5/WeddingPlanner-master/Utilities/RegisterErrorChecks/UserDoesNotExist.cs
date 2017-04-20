using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class UserDoesNotExists : ValidationAttribute
    {
        private WeddingPlannerContext _context;
    
        public UserDoesNotExists()
        {
            
        }
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            string setVal = value.ToString();
            try
            {
                
                List<User> allUsers = _context.Users.Where(users => users.Email == setVal).ToList();
                return ValidationResult.Success;
            }
            catch(Exception e)
            {
                return new ValidationResult ("Email doesn't exists in the Database." + setVal);   
            }
        }
    }
}