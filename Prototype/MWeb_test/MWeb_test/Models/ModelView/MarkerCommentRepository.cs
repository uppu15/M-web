using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MWeb_test.Models;

namespace MWeb_test.Models.ModelView
{
    public class MarkerCommentRepository
    {
        public IEnumerable<Userss> Usersses { get; set; }
        public IEnumerable<Markers> Markers { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
    }
}
