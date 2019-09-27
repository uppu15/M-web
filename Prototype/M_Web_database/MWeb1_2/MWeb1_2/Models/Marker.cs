using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb1_2.Models
{
    public class Marker
    {
        public int userID { get; set; }
        public string markerID { get; set; }
        public double markerLat { get; set; }
        public double markerLng { get; set; }
        public string photo { get; set; }
        public string photoPath { get; set; }
    }
}
