namespace BannerlordUnits.WebAPI.Apis;

public class CustomTroopsApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/Troops", Get)
            .Produces<List<CustomTroop>>()
            .WithName("GetAllTroops")
            .WithTags("Getters");

        app.MapGet("/Troops/{name}", GetByName)
            .Produces<CustomTroop>()
            .WithName("GetTroop")
            .WithTags("Getters");

        app.MapGet("/Troops/Amount/{number}", GetAmount)
            .Produces<List<CustomTroop>>()
            .WithName("GetAmountTroops")
            .WithTags("Getters");

        app.MapGet("/Troops/Names", GetNames)
            .Produces<List<string>>()
            .WithName("GetAllTroopsNames")
            .WithTags("Getters");

        app.MapPost("/Troops", Post)
            .Accepts<CustomTroop>("application/json")
            .Produces<CustomTroop>(StatusCodes.Status201Created)
            .WithName("CreateTroop")
            .WithTags("Creators");

        app.MapPut("/Troops", Put)
            .Accepts<CustomTroop>("application/json")
            .WithName("UpdateTroop")
            .WithTags("Updaters");

        app.MapDelete("/Troops/{id}", Delete)
            .WithName("DeleteTroop")
            .WithTags("Deleters");

        app.MapGet("/Troops/Search/Culture/{culture}", SearchByCulture)
            .Produces<IEnumerable<CustomTroop>>()
            .WithName("Search troops by culture")
            .WithTags("Searchers");

        app.MapGet("/Troops/Search/Type/{type}", SearchByType)
            .Produces<IEnumerable<CustomTroop>>()
            .WithName("Search troops by type")
            .WithTags("Searchers");
    }

    private async Task<IResult> Get(ITroopsRepository<CustomTroop> troopsRepository)
    {
        return Results.Json((await troopsRepository.GetTroopsAsync()).ToArray());
    }

    private async Task<IResult> GetAmount(ITroopsRepository<CustomTroop> troopsRepository, int amount)
    {
        return Results.Json((await troopsRepository.GetTroopsAsync(amount)).ToArray());
    }

    private async Task<IResult> GetByName(string name, ITroopsRepository<CustomTroop> troopsRepository)
    {
        return await troopsRepository.GetTroopAsync(name) is CustomTroop troop
            ? Results.Ok(troop)
            : Results.NotFound();
    }
    
    [Authorize]
    private async Task<IResult> GetNames(ITroopsRepository<CustomTroop> troopsRepository)
    {
        return Results.Ok(await troopsRepository.GetTroopsNamesAsync());
    }

    private IResult SearchByType(string type, ITroopsRepository<CustomTroop> troopsRepository)
    {
        return troopsRepository.SearchByTroopsType(type).ToArray() is IEnumerable<ITroop> result
            ? Results.Ok(result)
            : Results.NotFound(Array.Empty<CustomTroop>());
    }

    private IResult SearchByCulture(string culture, ITroopsRepository<CustomTroop> troopsRepository)
    {
        return troopsRepository.SearchByTroopsCulture(culture).ToArray() is IEnumerable<ITroop> result
            ? Results.Ok(result)
            : Results.NotFound(Array.Empty<CustomTroop>());
    }

    private async Task<IResult> Post(CustomTroop troop, ITroopsRepository<CustomTroop> troopsRepository)
    {
        await troopsRepository.InsertTroopAsync(troop);
        await troopsRepository.SaveAsync();
        return Results.Created($"/Troops/{troop.Name}", troop);
    }

    private async Task<IResult> Put(CustomTroop troop, ITroopsRepository<CustomTroop> troopsRepository)
    {
        await troopsRepository.UpdateTroopAsync(troop);
        await troopsRepository.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(string name, ITroopsRepository<CustomTroop> troopsRepository)
    {
        await troopsRepository.DeleteTroopAsync(name);
        await troopsRepository.SaveAsync();
        return Results.NoContent();
    }
}