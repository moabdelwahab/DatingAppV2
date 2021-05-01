using Microsoft.EntityFrameworkCore;
using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Presistence
{
    public class DatingAppContext : DbContext
    {
        public DatingAppContext( DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<AppUser> Users { get; set; } 

    }
}
