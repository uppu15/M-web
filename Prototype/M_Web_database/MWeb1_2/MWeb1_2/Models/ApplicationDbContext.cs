using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace MWeb1_2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Marker> Markers { get; set; }
        public DbSet<Users> Userss { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
