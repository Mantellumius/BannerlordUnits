namespace BannerlordUnits.WebAPI.Models;

[PrimaryKey(nameof(Name))]
public class CustomTroop : ITroop
{
    public Guid AuthorId { get; set; }
    public string Name { get; set; } = null!;
    public int Tier { get; set; }
    public string? Type { get; set; }
    public string? Culture { get; set; }
    public int Wage { get; set; }
    public string? ImageUrl { get; set; }
    public string? IconUrl { get; set; }
    public int OneHanded { get; set; }
    public int TwoHanded { get; set; }
    public int Polearm { get; set; }
    public int Bow { get; set; }
    public int Crossbow { get; set; }
    public int Throwing { get; set; }
    public int Riding { get; set; }
    public int Athletics { get; set; }
    public int Crafting { get; set; }
}