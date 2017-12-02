using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChristmasCalendar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DailyScore> DailyScore { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<FirstTimeOpeningDoor> FirstTimeOpeningDoor { get; set; }
        public DbSet<DailyScoreLastUpdated> DailyScoreLastUpdated { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DailyScore>().ToTable("DailyScore");
            builder.Entity<Door>().ToTable("Door");
            builder.Entity<Answer>().ToTable("Answer");
            builder.Entity<FirstTimeOpeningDoor>().ToTable("FirstTimeOpeningDoor");
            builder.Entity<DailyScoreLastUpdated>().ToTable("DailyScoreLastUpdated");

            builder.Entity<DailyScore>()
                .HasIndex(u => new { u.DoorId, u.UserId })
                .IsUnique()
                .HasName("UQ_UniqueUserEntryPerDoor");

            base.OnModelCreating(builder);
        }
    }
}
