using Microsoft.EntityFrameworkCore;
using Mission10_Baldwin.Models;

namespace Mission10_Baldwin.Data;

// Context for the Bowling League database

public class BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options) : DbContext(options)
{
    public DbSet<Bowler> Bowlers => Set<Bowler>();
    public DbSet<Team> Teams => Set<Team>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>()
            .HasOne(b => b.Team)
            .WithMany(t => t.Bowlers)
            .HasForeignKey(b => b.TeamId);
    }
}
