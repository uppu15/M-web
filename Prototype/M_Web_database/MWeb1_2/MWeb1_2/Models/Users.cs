using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MWeb1_2.Models
{
    public class Users
    {
        public Users()
        {
            Comments = new HashSet<Comment>();
            Markers = new HashSet<Marker>();
            UserSettings = new HashSet<UserSetting>();
        }

        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public byte[] created { get; set; }
        public string userStatus { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
        public virtual ICollection<UserSetting> UserSettings { get; set; }
    }
}
