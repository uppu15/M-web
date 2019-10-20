using System;
using System.Collections.Generic;

namespace MWeb_test1.Models
{
    public partial class Marker
    {
        public Marker()
        {
            Comment = new HashSet<Comment>();
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
            }
            private set
            {
                
            }
        }
        //public void SetMarkerJson()
        //{
        //    var generateString = "'{ \"MarkerLat\" : \"" + MarkerLat + "\", \"MarkerLng\"" + MarkerLng + "\", \"photo\" : \"" + Photo + "\" }'";
        //}

        public virtual Users User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
