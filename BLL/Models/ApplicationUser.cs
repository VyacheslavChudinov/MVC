using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BLL.Models
{
    public class ApplicationUser : IdentityUser<Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        [Required]
        [MaxLength(32, ErrorMessage = "Name must be {0} characters or less")]
        public string Name { get; set; }
        [Required]
        [MaxLength(64, ErrorMessage = "Last name must be {0} characters or less")]
        public string LastName { get; set; }
        public virtual ICollection<DAL.Models.Post> Posts { get; set; }
        public virtual DAL.Models.AccountType AccountType { get; set; }
        public virtual DAL.Models.AccountStatus AccountStatus { get; set; }
    }
}
