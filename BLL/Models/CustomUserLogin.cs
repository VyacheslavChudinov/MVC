using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BLL.Models
{    
    public class CustomUserLogin : IdentityUserLogin<Guid> { }
}