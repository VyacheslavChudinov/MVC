using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Language: Identity
    {
        [Required]
        [MaxLength(32, ErrorMessage = "Language name must be {0} characters or less")]
        public string Name { get; set; }
    }
}