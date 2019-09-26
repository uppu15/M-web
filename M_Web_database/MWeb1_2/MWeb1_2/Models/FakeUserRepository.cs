using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb1_2.Models
{
    public class FakeUserRepository : IUserRepository
    {
        public IQueryable<User> Users => new List<User>
        {
            new User { userID = 1, userPassword = "1234" },
            new User { userID = 2, userPassword = "qwer" },
            new User { userID = 3, userPassword = "asdf" },
            new User { userID = 4, userPassword = "zxcv" }
        }.AsQueryable<User>();
    }
}
