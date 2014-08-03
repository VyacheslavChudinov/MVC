using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    public class Post : Identity
    {
        public  string Name { get; set; }
        public  string Content { get; set; }              
        public  DateTime? CreationDate { get; set; }
        public  WorkingLife WorkingLife { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public Guid LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } 
    }
}