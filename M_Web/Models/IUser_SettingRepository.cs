using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Web.Models
{
    public class IUser_SettingRepository
    {
        IQueryable<User_Setting> user_Settings { get; }
    }
}
