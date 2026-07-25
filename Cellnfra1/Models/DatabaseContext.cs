using Microsoft.EntityFrameworkCore;

namespace Cellnfra1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<tbl_Account> tbl_CMSAccounts { get; set; }
        public DbSet<tbl_PostContent> tbl_CMSPostContents { get; set; }
    }
}
