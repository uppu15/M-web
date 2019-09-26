using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Web.Models
{
    public class ICommentRepository
    {
        IQueryable<Comment> comments { get; }
    }
}
