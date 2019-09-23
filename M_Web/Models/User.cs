using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace M_Web.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string password { get; set; }

        [DataType(DataType.Date)]
        public DateTime created { get; set; }

        public bool userStatus { get; set; } //verified user?
    }
}
