using System;
using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace ListingsManager.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Title of listing")]
        public string Name { get; set; }
        [Display(Name = "Listing")]
        public string Content { get; set; }
        [Display(Name = "Programming language")]
        public Language Language { get; set; }
        [Display(Name = "WorkingLife")]
        public WorkingLife WorkingLife { get; set; }
        [Display(Name = "Author")]
        public virtual ApplicationUser Author { get; set; }
        [Display(Name = "Creation date")]
        public DateTime? CreationDate { get; set; }
        [Display(Name = "Language Id")]
        public Guid LanguageId { get; set; }
    }
}