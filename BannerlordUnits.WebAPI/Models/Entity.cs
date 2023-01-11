namespace BannerlordUnits.WebAPI.Models;

[PrimaryKey(nameof(Id))]
public class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; } = default!;
}