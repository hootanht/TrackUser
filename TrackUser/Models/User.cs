using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackUser.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string IP { get; set; }
        public string PathVisit { get; set; }
        public bool Online { get; set; }
        public DateTime StartAt { get; set; }
    }
}
