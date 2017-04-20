using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Guest : BaseEntity
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User { get; set; }
        [ForeignKey("Wedding")]
        public int wedding_id { get; set; }
        public Wedding Wedding { get; set; }
    }
}