using System;
using System.Collections.Generic;

namespace MWeb_test1.Models
{
    public partial class Users
    {
        public Users()
        {
            Comment = new HashSet<Comment>();
            Marker = new HashSet<Marker>();
            UserSetting = new HashSet<UserSetting>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public byte[] Created { get; set; }
        public string UserStatus { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Marker> Marker { get; set; }
        public virtual ICollection<UserSetting> UserSetting { get; set; }
    }
}
