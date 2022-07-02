using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment.Models
{
    public class Units
    {
        [Key]
        public int unitId { get; set; }
        [Required]
        public string unitName { get; set; }
        [Required]
        public int unitLevel { get; set; }   // 0 -4
        [Required]
        public int parentId { get; set; } // Parent UnitID // @TODO : change its name unit_id 
    }
}
