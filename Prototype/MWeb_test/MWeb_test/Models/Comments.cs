using System;
using System.Collections.Generic;

namespace MWeb_test.Models
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public int MarkerId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }

        public virtual Markers Marker { get; set; }
        public virtual Userss User { get; set; }
    }
}
