using Microsoft.EntityFrameworkCore;

namespace ExercicioCDA.Models
{
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options) {}

        public DbSet<Users> Users { get; set; }
        public DbSet<CriminalCodes> CriminalCodes { get; set; }
        public DbSet<Status> Status { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Users>().ToTable("Users");
            //builder.Entity<CriminalCodes>().ToTable("CriminalCodes");
            //builder.Entity<Status>().ToTable("Status");
        }


    }
}
