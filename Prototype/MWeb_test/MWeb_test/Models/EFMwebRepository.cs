using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb_test.Models
{
    public class EFMwebRepository : IMwebRepository
    {
        private Mweb_DataTableFirstContext context;

        public EFMwebRepository(Mweb_DataTableFirstContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Userss> usersses => context.Userss;
        public IQueryable<Markers> markers => context.Markers;
        public IQueryable<Comments> comments => context.Comments;
    }
}
