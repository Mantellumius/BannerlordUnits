namespace BannerlordUnits.WebAPI.Apis;

public class TroopsApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/Troops", Get)
            .Produces<List<Troop>>()
            .WithName("GetAllTroops")
            .WithTags("Getters");

        app.MapGet("/Troops/{name}", GetByName)
            .Produces<Troop>()
            .WithName("GetTroop")
            .WithTags("Getters");

        app.MapGet("/Troops/Amount/{number}", GetAmount)
            .Produces<List<Troop>>()
            .WithName("GetAmountTroops")
            .WithTags("Getters");

        app.MapGet("/Troops/Names", GetNames)
            .Produces<List<string>>()
            .WithName("GetAllTroopsNames")
            .WithTags("Getters");

        app.MapPost("/Troops", Post)
            .Accepts<Troop>("application/json")
            .Produces<Troop>(StatusCodes.Status201Created)
            .WithName("CreateTroop")
            .WithTags("Creators");

        app.MapPut("/Troops", Put)
            .Accepts<Troop>("application/json")
            .WithName("UpdateTroop")
            .WithTags("Updaters");

        app.MapDelete("/Troops/{id}", Delete)
            .WithName("DeleteTroop")
            .WithTags("Deleters");

        app.MapGet("/Troops/Search/Culture/{culture}", SearchByCulture)
            .Produces<IEnumerable<Troop>>()
            .WithName("Search troops by culture")
            .WithTags("Searchers");

        app.MapGet("/Troops/Search/Type/{type}", SearchByType)
            .Produces<IEnumerable<Troop>>()
            .WithName("Search troops by type")
            .WithTags("Searchers");
    }

    private async Task<IResult> Get(ITroopsRepository<Troop> troopsRepository)
    {
        return Results.Json((await troopsRepository.GetTroopsAsync()).ToArray());
    }

    private async Task<IResult> GetAmount(ITroopsRepository<Troop> troopsRepository, int amount)
    {
        return Results.Json((await troopsRepository.GetTroopsAsync(amount)).ToArray());
    }

    private async Task<IResult> GetByName(string name, ITroopsRepository<Troop> troopsRepository)
    {
        return await troopsRepository.GetTroopAsync(name) is Troop troop
            ? Results.Ok(troop)
            : Results.NotFound();
    }
    
    [Authorize]
    private async Task<IResult> GetNames(ITroopsRepository<Troop> troopsRepository)
    {
        return Results.Ok(await troopsRepository.GetTroopsNamesAsync());
    }

    private IResult SearchByType(string type, ITroopsRepository<Troop> troopsRepository)
    {
        return troopsRepository.SearchByTroopsType(type).ToArray() is IEnumerable<ITroop> result
            ? Results.Ok(result)
            : Results.NotFound(Array.Empty<Troop>());
    }

    private IResult SearchByCulture(string culture, ITroopsRepository<Troop> troopsRepository)
    {
        return troopsRepository.SearchByTroopsCulture(culture).ToArray() is IEnumerable<ITroop> result
            ? Results.Ok(result)
            : Results.NotFound(Array.Empty<Troop>());
    }

    private async Task<IResult> Post(Troop troop, ITroopsRepository<Troop> troopsRepository)
    {
        await troopsRepository.InsertTroopAsync(troop);
        await troopsRepository.SaveAsync();
        return Results.Created($"/Troops/{troop.Name}", troop);
    }

    private async Task<IResult> Put(Troop troop, ITroopsRepository<Troop> troopsRepository)
    {
        await troopsRepository.UpdateTroopAsync(troop);
        await troopsRepository.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(string name, ITroopsRepository<Troop> troopsRepository)
    {
        await troopsRepository.DeleteTroopAsync(name);
        await troopsRepository.SaveAsync();
        return Results.NoContent();
    }
}