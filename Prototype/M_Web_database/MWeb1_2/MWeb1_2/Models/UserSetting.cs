using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MWeb1_2.Models
{
    public class UserSetting
    {
        [Key]
        public int settingID { get; set; }
        public int userID { get; set; }
        public decimal centerLat { get; set; }
        public decimal centerLng { get; set; }
        public int centerZoom { get; set; }
        public string mapType { get; set; }
        public int pinRadius { get; set; }
        public bool Gps { get; set; }

        public virtual Users Userss { get; set; }
    }
}
