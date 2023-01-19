namespace BannerlordUnits.WebAPI.DataAccess.Repositories;

public class TroopsRepository : IRepository<Troop>
{
    public MyDbContext Context { get; }
    private PropertyInfo[] Properties { get; }

    public TroopsRepository(MyDbContext context)
    {
        Context = context;
        Properties = typeof(Troop).GetProperties();
    }

    public Task<List<Troop>> GetAllAsync() => Context.Troops.ToListAsync();
    public Task<List<Troop>> GetAmountAsync(int amount) => Context.Troops.Take(amount).ToListAsync();
    public async Task<Troop> GetByNameAsync(string name) => (await Context.Troops.FindAsync(name))!;
    public async Task InsertAsync(Troop troop) => await Context.Troops.AddAsync(troop);

    public async Task UpdateAsync(Troop troop)
    {
        var troopFromDb = await Context.Troops.FindAsync(troop.Name);
        if (troopFromDb == null) return;
        foreach (var property in Properties)
            property.SetValue(troopFromDb, property.GetValue(troop));
    }

    public async Task DeleteAsync(string name)
    {
        var troopFromDb = await Context.Troops.FindAsync(name);
        if (troopFromDb == null) return;
        Context.Troops.Remove(troopFromDb);
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

public static class RepositoryTroopExtensions
{
    public static IEnumerable<Troop> SearchByTroopsCulture(this IRepository<Troop> repository, string culture) =>
        repository.Context.Troops.Where(troop => troop.Culture == culture).ToArray();

    public static IEnumerable<Troop> SearchByTroopsType(this IRepository<Troop> repository, string type) =>
        repository.Context.Troops.Where(troop => troop.Type == type).ToArray();

    public static Task<List<string>> GetTroopsNamesAsync(this IRepository<Troop> repository) =>
        repository.Context.Troops.Select(troop => troop.Name).ToListAsync();
}