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
        public string MarkerJson
        {
            get
            {
                return "'{ \"MarkerLat\" : \"" + MarkerLat + "\", \"MarkerLng\"" + MarkerLng + "\", \"photo\" : \"" + Photo + "\" }'";
                //'{"MarkerLat":32.68,"MarkerLng":-117.4,"photo":""}'
            }
        }

        public virtual Userss User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
