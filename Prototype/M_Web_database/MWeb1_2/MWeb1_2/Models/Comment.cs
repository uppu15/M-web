using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MWeb1_2.Models
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }
        public string markerID { get; set; }
        public int userID { get; set; }
        public string comments { get; set; }

        public virtual Marker Marker { get; set; }
        public virtual Users Userss { get; set; }
    }
}
