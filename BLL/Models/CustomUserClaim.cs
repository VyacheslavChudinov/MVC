using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BLL.Models
{
    public class CustomUserClaim : IdentityUserClaim<Guid> { }
}
