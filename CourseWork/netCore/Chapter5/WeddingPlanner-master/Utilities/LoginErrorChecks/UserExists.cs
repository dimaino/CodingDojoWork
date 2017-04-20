using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeddingPlanner.Controllers;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class UserExists : ValidationAttribute
    {
        private WeddingPlannerContext _context;
    
        public UserExists()
        {
        }
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            string setVal = "";
            if(value != null)
            {
                setVal = value.ToString();
            }
            try
            {
                User currentUser = _context.Users.SingleOrDefault(user => user.Email == setVal);
                if(currentUser != null && currentUser.Email.Equals(setVal))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult ("Email doesn't exists in the Database." + setVal); 
                }
            }
            catch(Exception e)
            {
                return new ValidationResult ("Email doesn't exists in the Database." + setVal);  
            }
        }
    }
}