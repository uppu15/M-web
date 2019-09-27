using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace M_Web.Models
{
    public class Marker
    {
        [Key]
        public int userID { get; set; }
        public int markerID { get; set; }
        public double markerLat { get; set; }
        public double markerLng { get; set; }
        //public string markerType { get; set; }
        //create column for image
    }
}
