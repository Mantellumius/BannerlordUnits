namespace BannerlordUnits.WebAPI.DataAccess.Repositories;

public class CompanionsRepository : IRepository<Companion>
{
    public MyDbContext Context { get; }
    private PropertyInfo[] Properties { get; }

    public CompanionsRepository(MyDbContext context)
    {
        Context = context;
        Properties = typeof(Companion).GetProperties();
    }

    public Task<List<Companion>> GetAllAsync() => Context.Companions.ToListAsync();
    public Task<List<Companion>> GetAmountAsync(int amount) => Context.Companions.Take(amount).ToListAsync();
    public async Task<Companion> GetByNameAsync(string name) => (await Context.Companions.FindAsync(name))!;


    public async Task InsertAsync(Companion companion) => await Context.Companions.AddAsync(companion);

    public async Task UpdateAsync(Companion companion)
    {
        var companionFromDb = await Context.Companions.FindAsync(companion.Name);
        if (companionFromDb == null) return;
        foreach (var property in Properties)
            property.SetValue(companionFromDb, property.GetValue(companion));
    }

    public async Task DeleteAsync(string name)
    {
        var companionFromDb = await Context.Companions.FindAsync(name);
        if (companionFromDb == null) return;
        Context.Companions.Remove(companionFromDb);
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

public static class RepositoryCompanionsExtensions
{
    public static Task<List<string>> GetNamesAsync(this IRepository<Companion> repository) =>
        repository.Context.Companions.Select(companion => companion.Name).ToListAsync();

    public static IEnumerable<Companion>
        SearchByCultureAsync(this IRepository<Companion> repository, string culture) =>
        repository.Context.Companions.Where(companion => companion.Culture == culture).ToArray();
}