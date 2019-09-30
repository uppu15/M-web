using System.Collections.Generic;
using System.Linq;

namespace MWeb1_2.Models
{
    public class EFUserSettingRepository : IUserSettingRepository
    {
        private ApplicationDbContext context;

        public EFUserSettingRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<UserSetting> UserSettings => context.UserSettings;
    }
}
