using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Practice.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }

        public bool Terms { get; set; }
    }
}