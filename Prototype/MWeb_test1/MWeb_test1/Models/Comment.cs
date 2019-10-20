using System;
using System.Collections.Generic;

namespace MWeb_test1.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int MarkerId { get; set; }
        public int UserId { get; set; }
        public string Comment1 { get; set; }

        public virtual Marker Marker { get; set; }
        public virtual Users User { get; set; }
    }
}
