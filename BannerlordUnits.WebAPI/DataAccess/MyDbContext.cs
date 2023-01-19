namespace BannerlordUnits.WebAPI.DataAccess;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Troop> Troops { get; set; }
    public DbSet<CustomTroop> CustomTroops { get; set; }
    public DbSet<Companion> Companions { get; set; }
}