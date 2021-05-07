using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinoApp.Areas.Kino.Models
{
    public class EmployeeModel
    {
        public int IdEmpl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfEmpl { get; set; }
    }
}