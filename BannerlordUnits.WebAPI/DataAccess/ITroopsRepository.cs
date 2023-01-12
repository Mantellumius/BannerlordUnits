using BannerlordUnits.Models;

namespace BannerlordUnits.WebAPI.DataAccess;

public interface ITroopsRepository<TTroop>
{
    Task<List<Troop>> GetTroopsAsync();
    Task<TTroop> GetTroopAsync(string name);
    IEnumerable<TTroop> SearchByTroopsCulture(string culture);
    IEnumerable<TTroop> SearchByTroopsType(string type);
    Task InsertTroopAsync(TTroop unit);
    Task UpdateTroopAsync(TTroop unit);
    Task DeleteTroopAsync(string Name);
    Task SaveAsync();
}