using System.Collections.Generic;
using System.Linq;

namespace MWeb1_2.Models
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.Users;
    }
}
