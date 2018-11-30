using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace WebDel3Part2.Models
{
    public class User : IdentityUser
    {
        public string UserId { get; set; }
        public string Email { get; set; }
    }
}