using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsFixture.Models;
using System.Reflection.Emit;

namespace SportsFixture.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SportFixture> SportFixtures { get; set; }
        public DbSet<SportTeam> SportTeams { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<SportCompetition> SportCompetition { get; set; }

        public DbSet<Subscriptions> Subscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MatchEvent>().ToTable("MatchEvent");
            builder.Entity<MatchEvent>()
            .HasOne(m => m.HomeTeam)
            .WithMany()
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MatchEvent>()
            .HasOne(m => m.AwayTeam)
            .WithMany()
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TeamSubscription>().ToTable("TeamSubscriptions");
            builder.Entity<MatchEvent>().HasBaseType<SportFixture>();
            builder .Entity<MultiTeamEvent>().HasBaseType<SportFixture>();


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER",
                }
            );
            //   builder.Entity<SportCompetition>().HasMany(f => f.AllFixtures).WithOne(f => f.) 
        }

    }
}
