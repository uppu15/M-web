using System.Collections.Generic;
using System.Linq;

namespace MWeb1_2.Models
{
    public class EFMarkerRepository : IMarkerRepository
    {
        private ApplicationDbContext context;

        public EFMarkerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Marker> Markers => context.Markers;
    }
}
