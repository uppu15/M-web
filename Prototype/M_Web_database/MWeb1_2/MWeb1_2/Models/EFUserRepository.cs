using System.Collections.Generic;
using System.Linq;

namespace MWeb1_2.Models
{
    public class EFUserRepository : IUsersRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Users> Userss => context.Userss;
    }
}
