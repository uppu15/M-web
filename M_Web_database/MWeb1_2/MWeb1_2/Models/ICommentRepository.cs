using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb1_2.Models
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
    }
}
