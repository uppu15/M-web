using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        public string UserPassword { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("UserPassword", ErrorMessage = "Password and confirmation password do not match")]
        //public string ConfirmPassword { get; set; }

        public byte[] Created { get; set; }
        [ScaffoldColumn(false)]
        public string UserStatus { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Markers> Markers { get; set; }
        public virtual ICollection<UserSettings> UserSettings { get; set; }
    }
}
