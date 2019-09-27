using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb1_2.Models
{
    public class FakeMarkerRepository : IMarkerRepository
    {
        public IQueryable<Marker> Markers => new List<Marker>
        {
            new Marker { markerID = "qwer1", markerLat = 32.818609, markerLng = -117.143261 },
            new Marker { markerID = "asdf2", markerLat = 32.824632, markerLng = -117.126781 },
            new Marker { markerID = "zxcv3", markerLat = 32.810314, markerLng = -117.131116 }
        }.AsQueryable<Marker>();
    }
}
