using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment.Models
{
    public class Employees
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string fullName { get; set; }
        public string number { get; set; }
        public string jobTitle { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        // Foreign key
        public Units units { get; set; }
    }
}
