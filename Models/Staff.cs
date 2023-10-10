using System.ComponentModel.DataAnnotations;

namespace WebApplication45.Models
{
    public class Staff {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
