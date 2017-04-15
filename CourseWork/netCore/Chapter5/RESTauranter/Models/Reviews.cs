using System;
namespace RESTauranter.Models
{
    public class Reviews : BaseEntity
    {
        public int id {get;set;}
        public string Reviewer_Name {get;set;}
        public string Restaurant_Name {get;set;}
        public string Review {get;set;}
        public DateTime Date_Visited {get;set;}
        public int Stars {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
}