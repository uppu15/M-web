using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MWeb_test.Models;

namespace MWeb_test.Models.ModelView
{
    public class MarkerCommentRepository
    {
        public IEnumerable<Userss> usersses { get; set; }
        public IEnumerable<Markers> markers { get; set; }
        public IEnumerable<Comments> comments { get; set; }
    }
}
