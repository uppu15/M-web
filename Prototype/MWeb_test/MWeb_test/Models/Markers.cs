using System;
using System.Collections.Generic;

namespace MWeb_test.Models
{
    public partial class Markers
    {
        public Markers()
        {
            Comments = new HashSet<Comments>();
        }

        public int MarkerId { get; set; }
        public int UserId { get; set; }
        public decimal MarkerLat { get; set; }
        public decimal MarkerLng { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoPath { get; set; }
        //public string MarkerJson { get; set; }


        public virtual Userss User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
