using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MWeb1_2.Models
{
    public class Marker
    {
        public Marker()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public string markerID { get; set; }
        public int userID { get; set; }
        public double markerLat { get; set; }
        public double markerLng { get; set; }
        public byte[] photo { get; set; }
        public string photoPath { get; set; }

        public virtual Users Userss { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
