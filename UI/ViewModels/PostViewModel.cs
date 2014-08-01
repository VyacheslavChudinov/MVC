using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace ListingsManager.ViewModels
{
    public class PostViewModel
    {
        [Display(Name = "Title of listing")]
        public string Name { get; set; }
        [Display(Name = "Listing")]
        public string Content { get; set; }
        [Display(Name = "Programming language")]
        public string Language { get; set; }
        [Display(Name = "WorkingLife")]
        public WorkingLife WorkingLife { get; set; }
    }
}