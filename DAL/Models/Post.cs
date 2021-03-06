﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Post : Identity
    {
        [Required]
        [MaxLength(64, ErrorMessage="Post name must be {0} characters or less")]
        public  string Name { get; set; }
        [Required]
        [MaxLength(-1)]
        public  string Content { get; set; }
        [Required]
        public  DateTime? CreationDate { get; set; }
        [Required]
        public  WorkingLife WorkingLife { get; set; }        
        public virtual ApplicationUser Author { get; set; }
        public Guid LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } 
    }
}