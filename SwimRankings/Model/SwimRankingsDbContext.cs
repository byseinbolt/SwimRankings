using Microsoft.EntityFrameworkCore;

namespace SwimRankings;

public sealed class SwimRankingsDbContext : DbContext
{
    public SwimRankingsDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=SwimRankingsDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
    }


    public DbSet<Swimmer> Swimmers => Set<Swimmer>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Distance> Distances => Set<Distance>();
    public DbSet<Result> Results => Set<Result>();

}