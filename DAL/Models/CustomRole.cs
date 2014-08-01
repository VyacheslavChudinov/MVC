using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class CustomRole : IdentityRole<Guid, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
