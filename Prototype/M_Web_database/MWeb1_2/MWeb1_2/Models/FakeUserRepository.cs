using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWeb1_2.Models
{
    public class FakeUserRepository : IUsersRepository
    {
        public IQueryable<Users> Userss => new List<Users>
        {
            new Users { userID = 1, userPassword = "1234" },
            new Users { userID = 2, userPassword = "qwer" },
            new Users { userID = 3, userPassword = "asdf" },
            new Users { userID = 4, userPassword = "zxcv" }
        }.AsQueryable<Users>();
    }
}
