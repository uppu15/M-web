using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace M_Web.Models
{
    public class User_Setting
    {
        [Key]
        public int userID { get; set; }
        public decimal centerLat { get; set; }
        public decimal centerLng { get; set; }
        public int centerZoom { get; set; }
        public bool mapType { get; set; }
        public int pinRadius { get; set; }
        public bool GPS { get; set; }
    }
}
