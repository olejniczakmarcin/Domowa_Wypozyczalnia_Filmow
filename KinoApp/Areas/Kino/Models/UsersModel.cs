using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinoApp.Areas.Kino.Models
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}