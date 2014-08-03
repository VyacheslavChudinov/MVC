using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class Language: BLL.Models.Identity
    {
        [Required]
        [MaxLength(32, ErrorMessage = "Language name must be {0} characters or less")]
        public string Name { get; set; }
    }
}