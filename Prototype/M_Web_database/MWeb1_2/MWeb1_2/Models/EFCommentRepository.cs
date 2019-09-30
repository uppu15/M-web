using System.Collections.Generic;
using System.Linq;

namespace MWeb1_2.Models
{
    public class EFCommentRepository : ICommentRepository
    {
        private ApplicationDbContext context;

        public EFCommentRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Comment> Comments => context.Comments;
    }
}
