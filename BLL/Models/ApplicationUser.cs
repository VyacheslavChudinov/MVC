using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BLL.Models
{
    public class ApplicationUser : IdentityUser<Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual AccountStatus AccountStatus { get; set; }
    }
}
