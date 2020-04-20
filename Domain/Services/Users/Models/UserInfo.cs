using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Services.Users.Models
{
    public class UserInfo
    {
        public int IdUser { get; set; }
        public int IdGroup { get; set; }
        public int TypeUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
