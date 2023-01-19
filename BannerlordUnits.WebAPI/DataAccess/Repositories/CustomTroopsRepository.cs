namespace BannerlordUnits.WebAPI.DataAccess.Repositories;

public class CustomTroopsRepository : IRepository<CustomTroop>
{
    public MyDbContext Context { get; }
    private PropertyInfo[] Properties { get; }

    public CustomTroopsRepository(MyDbContext context)
    {
        Context = context;
        Properties = typeof(CustomTroop).GetProperties();
    }

    public Task<List<CustomTroop>> GetAllAsync() => Context.CustomTroops.ToListAsync();
    public Task<List<CustomTroop>> GetAmountAsync(int amount) => Context.CustomTroops.Take(amount).ToListAsync();
    public async Task<CustomTroop> GetByNameAsync(string name) => (await Context.CustomTroops.FindAsync(name))!;
    public async Task InsertAsync(CustomTroop troop) => await Context.CustomTroops.AddAsync(troop);

    public async Task UpdateAsync(CustomTroop troop)
    {
        var troopFromDb = await Context.CustomTroops.FindAsync(troop.Name);
        if (troopFromDb == null) return;
        foreach (var property in Properties)
            property.SetValue(troopFromDb, property.GetValue(troop));
    }

    public async Task DeleteAsync(string name)
    {
        var troopFromDb = await Context.CustomTroops.FindAsync(name);
        if (troopFromDb == null) return;
        Context.CustomTroops.Remove(troopFromDb);
    }

    public async Task SaveAsync() => await Context.SaveChangesAsync();

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

public static class RepositoryCustomTroopExtensions
{
    public static IEnumerable<CustomTroop> SearchByTroopsCulture(this IRepository<CustomTroop> repository,
        string culture) =>
        repository.Context.CustomTroops.Where(troop => troop.Culture == culture).ToArray();

    public static IEnumerable<CustomTroop> SearchByTroopsType(this IRepository<CustomTroop> repository, string type) =>
        repository.Context.CustomTroops.Where(troop => troop.Type == type).ToArray();

    public static Task<List<string>> GetTroopsNamesAsync(this IRepository<CustomTroop> repository) =>
        repository.Context.CustomTroops.Select(troop => troop.Name).ToListAsync();
}