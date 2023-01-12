using BannerlordUnits.Models;

namespace BannerlordUnits.WebAPI.DataAccess;

public class TroopsContext : DbContext
{
    public TroopsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Troop> Troops { get; set; }
    public DbSet<CustomTroop> CustomTroops { get; set; }
}