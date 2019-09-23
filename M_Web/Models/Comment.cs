using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace M_Web.Models
{
    public class Comment
    {
        [Key]
        public int markerID { get; set; }
        public int userID { get; set; }
        public string comment { get; set; }
    }
}
