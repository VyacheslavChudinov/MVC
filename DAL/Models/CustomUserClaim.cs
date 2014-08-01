using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class CustomUserClaim : IdentityUserClaim<Guid> { }
}
