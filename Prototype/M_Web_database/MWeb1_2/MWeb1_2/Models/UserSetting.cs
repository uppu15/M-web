using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb1_2.Models
{
    public class UserSetting
    {
        public int userID { get; set; }
        public double centerLat { get; set; }
        public double centerLng { get; set; }
        public int centerZoom { get; set; }
        public string mapType { get; set; }
        public int pinRadius { get; set; }
        public bool GPS { get; set; }
    }
}
