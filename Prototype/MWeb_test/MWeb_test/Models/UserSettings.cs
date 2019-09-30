using System;
using System.Collections.Generic;

namespace MWeb_test.Models
{
    public partial class UserSettings
    {
        public int SettingId { get; set; }
        public int UserId { get; set; }
        public decimal CenterLat { get; set; }
        public decimal CenterLng { get; set; }
        public int CenterZoom { get; set; }
        public string MapType { get; set; }
        public int PinRadius { get; set; }
        public bool Gps { get; set; }

        public virtual Userss User { get; set; }
    }
}
