using Microsoft.EntityFrameworkCore;
using SaggiTimeSheet.Models;

namespace SaggiTimeSheet
{
    public class SaggiTimeSheetDbContext : DbContext
    {
        public SaggiTimeSheetDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<TimeSheet> timesheets{ get; set; }
        public DbSet<TimeSheetEntry> timesheetentries { get; set; }
        public DbSet<Approval> approvals { get; set; }


    }
}
