using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dockerdemocrud.Models
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }
    }
}
