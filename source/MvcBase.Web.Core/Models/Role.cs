using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcBase.Web.Core.Models
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Manager = "Manager";  
    }
    public enum UserRoles
    {
        Admin = 1,
        User = 2,    
        Manager = 3
    }
}
