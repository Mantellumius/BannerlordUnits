namespace BannerlordUnits.WebAPI.DataAccess.Repositories;

public interface IRepository<TObject> : IDisposable
    where TObject : IWithName
{
    public MyDbContext Context { get; }
    Task<List<TObject>> GetAllAsync();
    Task<List<TObject>> GetAmountAsync(int amount);
    Task<TObject> GetByNameAsync(string name);
    Task InsertAsync(TObject obj);
    Task UpdateAsync(TObject obj);
    Task DeleteAsync(string name);
    Task SaveAsync();
}