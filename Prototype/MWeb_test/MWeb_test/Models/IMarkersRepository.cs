using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb_test.Models
{
    public class IMarkersRepository
    {
        IQueryable<Markers> Markers { get; }
    }
}
