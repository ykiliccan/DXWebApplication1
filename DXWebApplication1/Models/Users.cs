using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public static class Users
    {
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User { Id = 1, Name = "User1", value = 0 });
            users.Add(new User { Id = 2, Name = "User2", value = 0 });
            users.Add(new User { Id = 3, Name = "User3", value = 0 });

            return users;
        }
    }
}