using System.ComponentModel.DataAnnotations;

namespace MvcPIN.Models
{
    public class PIN
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"\d{10}")]
        public string Name { get; set; }
    }
}
