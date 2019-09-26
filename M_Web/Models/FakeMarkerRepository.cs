using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Web.Models
{
    public class FakeMarkerRepository : IMarkerRepository
    {
        public IQueryable<Marker> markers => new List<Marker>
        {
            new Marker { userID = 1, markerID = 1 , markerLat = 32.80 , markerLng =-117.13 },
            new Marker { userID = 2, markerID = 2 , markerLat = 31 , markerLng = -118 }
        }.AsQueryable<Marker>();
    }
}
