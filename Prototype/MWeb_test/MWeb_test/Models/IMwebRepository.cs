using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb_test.Models
{
    public class IMwebRepository
    {
        IQueryable<Userss> usersses { get; }
        IQueryable<Markers> markers { get; }
        IQueryable<Comments> comments { get; }
    }
}
