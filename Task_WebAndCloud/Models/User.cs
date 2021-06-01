using Microsoft.AspNetCore.Identity;
using System;

namespace Task_WebAndCloud.Models
{
    public class User : IdentityUser
    {
        public string jobDescription { get; set; }

        public User(string user)
        {
            UserName = user;
        }

        public User()
        {
            
        }
    }
}
