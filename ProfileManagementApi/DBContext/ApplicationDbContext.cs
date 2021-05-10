using Microsoft.EntityFrameworkCore;
using ProfileManagementApi.Models;

namespace ProfileManagementApi.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Profiles> Profiles { get; set; }
    }
}