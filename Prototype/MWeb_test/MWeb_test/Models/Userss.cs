using System;
using System.Collections.Generic;

namespace MWeb_test.Models
{
    public partial class Userss
    {
        public Userss()
        {
            Comments = new HashSet<Comments>();
            Markers = new HashSet<Markers>();
            UserSettings = new HashSet<UserSettings>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public byte[] Created { get; set; }
        public string UserStatus { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Markers> Markers { get; set; }
        public virtual ICollection<UserSettings> UserSettings { get; set; }
    }
}
