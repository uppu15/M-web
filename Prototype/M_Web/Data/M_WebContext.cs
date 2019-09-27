using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace M_Web.Models
{
    public class M_WebContext : DbContext
    {
        public M_WebContext (DbContextOptions<M_WebContext> options)
            : base(options)
        {
        }

        public DbSet<M_Web.Models.User> User { get; set; }
    }
}
