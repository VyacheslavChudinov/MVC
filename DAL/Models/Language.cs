using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Language: Identity
    {
        public string Name { get; set; }
    }
}