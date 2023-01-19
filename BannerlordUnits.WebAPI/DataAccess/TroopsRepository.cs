namespace BannerlordUnits.WebAPI.DataAccess;

public class TroopsRepository : ITroopsRepository<Troop>
{
    private readonly MyDbContext _context;
    private PropertyInfo[] Properties { get; }

    public TroopsRepository(MyDbContext context)
    {
        _context = context;
        Properties = typeof(Troop).GetProperties();
    }

    public Task<List<Troop>> GetTroopsAsync() => _context.Troops.ToListAsync();
    public Task<List<string>> GetTroopsNamesAsync() => _context.Troops.Select(troop => troop.Name).ToListAsync();
    public Task<List<Troop>> GetTroopsAsync(int amount) => _context.Troops.Take(amount).ToListAsync();
    public async Task<Troop> GetTroopAsync(string name) => (await _context.Troops.FindAsync(name))!;

    public IEnumerable<Troop> SearchByTroopsCulture(string culture) =>
        _context.Troops.Where(troop => troop.Culture == culture).ToArray();

    public IEnumerable<Troop> SearchByTroopsType(string type) =>
        _context.Troops.Where(troop => troop.Type == type).ToArray();

    public async Task InsertTroopAsync(Troop troop) => await _context.Troops.AddAsync(troop);

    public async Task UpdateTroopAsync(Troop troop)
    {
        var troopFromDb = await _context.Troops.FindAsync(troop.Name);
        if (troopFromDb == null) return;
        foreach (var property in Properties)
            property.SetValue(troopFromDb, property.GetValue(troop));
    }

    public async Task DeleteTroopAsync(string name)
    {
        var troopFromDb = await _context.Troops.FindAsync(name);
        if (troopFromDb == null) return;
        _context.Troops.Remove(troopFromDb);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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