using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb1_2.Models
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public DateTime created { get; set; }
        public bool userStatus { get; set; }
    }
}
