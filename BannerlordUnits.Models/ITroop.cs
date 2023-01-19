namespace BannerlordUnits.Models;

public interface ITroop : IWithName
{
    string Name { get; set; }
    int Tier { get; set; }
    string? Type { get; set; }
    string? Culture { get; set; }
    int Wage { get; set; }
    string? ImageUrl { get; set; }
    string? IconUrl { get; set; }
    int OneHanded { get; set; }
    int TwoHanded { get; set; }
    int Polearm { get; set; }
    int Bow { get; set; }
    int Crossbow { get; set; }
    int Throwing { get; set; }
    int Riding { get; set; }
    int Athletics { get; set; }
}