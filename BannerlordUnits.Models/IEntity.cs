namespace BannerlordUnits.Models;

public interface IEntity<TId>
{
    TId Id { get; set; }
}