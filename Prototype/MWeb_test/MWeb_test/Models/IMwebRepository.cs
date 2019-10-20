using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb_test.Models
{
    public class IMwebRepository
    {
        IQueryable<Userss> Uersses { get; }
        IQueryable<Markers> Markers { get; }
        IQueryable<Comments> Comments { get; }
    }
}
