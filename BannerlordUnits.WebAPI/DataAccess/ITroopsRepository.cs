namespace BannerlordUnits.WebAPI.DataAccess;

public interface ITroopsRepository<TTroop>
{
    Task<List<Troop>> GetTroopsAsync();
    Task<List<Troop>> GetTroopsAsync(int amount);
    Task<TTroop> GetTroopAsync(string name);
    Task<List<string>> GetTroopsNamesAsync();
    IEnumerable<TTroop> SearchByTroopsCulture(string culture);
    IEnumerable<TTroop> SearchByTroopsType(string type);
    Task InsertTroopAsync(TTroop troop);
    Task UpdateTroopAsync(TTroop troop);
    Task DeleteTroopAsync(string name);
    Task SaveAsync();
}