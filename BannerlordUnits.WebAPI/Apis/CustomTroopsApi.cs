using BannerlordUnits.WebAPI.DataAccess.Repositories;

namespace BannerlordUnits.WebAPI.Apis;

public class CustomTroopsApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/CustomTroops", Get)
            .Produces<List<CustomTroop>>()
            .WithName("GetAllCustomTroops")
            .WithTags("Getters");

        app.MapGet("/CustomTroops/{name}", GetByName)
            .Produces<CustomTroop>()
            .WithName("GetCustomTroop")
            .WithTags("Getters");

        app.MapGet("/CustomTroops/Amount/{number}", GetAmount)
            .Produces<List<CustomTroop>>()
            .WithName("GetAmountCustomTroops")
            .WithTags("Getters");

        app.MapGet("/CustomTroops/Names", GetNames)
            .Produces<List<string>>()
            .WithName("GetAllCustomTroopsNames")
            .WithTags("Getters");

        app.MapPost("/CustomTroops", Post)
            .Accepts<CustomTroop>("application/json")
            .Produces<CustomTroop>(StatusCodes.Status201Created)
            .WithName("CreateCustomTroop")
            .WithTags("Creators");

        app.MapPut("/CustomTroops", Put)
            .Accepts<CustomTroop>("application/json")
            .WithName("UpdateCustomTroop")
            .WithTags("Updaters");

        app.MapDelete("/CustomTroops/{id}", Delete)
            .WithName("DeleteCustomTroop")
            .WithTags("Deleters");

        app.MapGet("/CustomTroops/Search/AuthorId/{id}", GetByAuthorId)
            .Produces<List<CustomTroop>>()
            .WithName("Search custom troops by author id")
            .WithTags("Searchers");
        
        app.MapGet("/CustomTroops/Search/Culture/{culture}", SearchByCulture)
            .Produces<IEnumerable<CustomTroop>>()
            .WithName("Search custom troops by culture")
            .WithTags("Searchers");

        app.MapGet("/CustomTroops/Search/Type/{type}", SearchByType)
            .Produces<IEnumerable<CustomTroop>>()
            .WithName("Search custom troops by type")
            .WithTags("Searchers");
    }


    private async Task<IResult> Get(IRepository<CustomTroop> troopsRepository)
    {
        return Results.Json((await troopsRepository.GetAllAsync()).ToArray());
    }

    private async Task<IResult> GetByAuthorId(IRepository<CustomTroop> troopsRepository, Guid id)
    {
        return Results.Json((await troopsRepository.GetAllAsync()).Where(troop => troop.AuthorId == id).ToList());
    }

    private async Task<IResult> GetAmount(IRepository<CustomTroop> troopsRepository, int amount)
    {
        return Results.Json((await troopsRepository.GetAmountAsync(amount)).ToArray());
    }

    private async Task<IResult> GetByName(string name, IRepository<CustomTroop> troopsRepository)
    {
        return await troopsRepository.GetByNameAsync(name) is CustomTroop troop
            ? Results.Ok(troop)
            : Results.NotFound();
    }

    [Authorize]
    private async Task<IResult> GetNames(IRepository<CustomTroop> troopsRepository)
    {
        return Results.Ok(await troopsRepository.GetTroopsNamesAsync());
    }

    private IResult SearchByType(string type, IRepository<CustomTroop> troopsRepository)
    {
        return troopsRepository.SearchByTroopsType(type).ToArray() is IEnumerable<ITroop> result
            ? Results.Ok(result)
            : Results.NotFound(Array.Empty<CustomTroop>());
    }

    private IResult SearchByCulture(string culture, IRepository<CustomTroop> troopsRepository)
    {
        return troopsRepository.SearchByTroopsCulture(culture).ToArray() is IEnumerable<ITroop> result
            ? Results.Ok(result)
            : Results.NotFound(Array.Empty<CustomTroop>());
    }

    private async Task<IResult> Post(CustomTroop troop, IRepository<CustomTroop> troopsRepository)
    {
        await troopsRepository.InsertAsync(troop);
        await troopsRepository.SaveAsync();
        return Results.Created($"/CustomTroops/{troop.Name}", troop);
    }

    private async Task<IResult> Put(CustomTroop troop, IRepository<CustomTroop> troopsRepository)
    {
        await troopsRepository.UpdateAsync(troop);
        await troopsRepository.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(string name, IRepository<CustomTroop> troopsRepository)
    {
        await troopsRepository.DeleteAsync(name);
        await troopsRepository.SaveAsync();
        return Results.NoContent();
    }
}

