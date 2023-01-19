using BannerlordUnits.WebAPI.DataAccess.Repositories;

namespace BannerlordUnits.WebAPI.Apis;

public class CompanionsApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/Companions", Get)
            .Produces<List<Companion>>()
            .WithName("GetAllCompanions")
            .WithTags("Getters");

        app.MapGet("/Companions/{name}", GetByName)
            .Produces<Companion>()
            .WithName("GetCompanionByName")
            .WithTags("Getters");

        app.MapGet("/Companions/Amount/{number}", GetAmount)
            .Produces<List<Companion>>()
            .WithName("GetAmountCompanions")
            .WithTags("Getters");

        app.MapGet("/Companions/Names", GetNames)
            .Produces<List<string>>()
            .WithName("GetAllCompanionsNames")
            .WithTags("Getters");

        app.MapPost("/Companions", Post)
            .Accepts<Companion>("application/json")
            .Produces<Companion>(StatusCodes.Status201Created)
            .WithName("CreateCompanion")
            .WithTags("Creators");

        app.MapPut("/Companions", Put)
            .Accepts<Companion>("application/json")
            .WithName("UpdateCompanion")
            .WithTags("Updaters");

        app.MapDelete("/Companions/{id}", Delete)
            .WithName("DeleteCompanion")
            .WithTags("Deleters");

        app.MapGet("/Companions/Search/AuthorId/{id}", GetByAuthorId)
            .Produces<List<Companion>>()
            .WithName("Search companions by author id")
            .WithTags("Searchers");

        app.MapGet("/Companions/Search/Culture/{culture}", SearchByCulture)
            .Produces<IEnumerable<Companion>>()
            .WithName("Search companions by culture")
            .WithTags("Searchers");
    }


    private async Task<IResult> Get(IRepository<Companion> companionsRepository)
    {
        return Results.Json((await companionsRepository.GetAllAsync()).ToArray());
    }

    private async Task<IResult> GetByAuthorId(IRepository<Companion> companionsRepository, Guid id)
    {
        return Results.Json((await companionsRepository.GetAllAsync()).Where(companion => companion.AuthorId == id)
            .ToList());
    }

    private async Task<IResult> GetAmount(IRepository<Companion> companionsRepository, int amount)
    {
        return Results.Json((await companionsRepository.GetAmountAsync(amount)).ToArray());
    }

    private async Task<IResult> GetByName(IRepository<Companion> companionsRepository, string name)
    {
        return await companionsRepository.GetByNameAsync(name) is Companion companion
            ? Results.Ok(companion)
            : Results.NotFound();
    }

    [Authorize]
    private async Task<IResult> GetNames(IRepository<Companion> companionsRepository)
    {
        return Results.Ok(await companionsRepository.GetNamesAsync());
    }

    private IResult SearchByCulture(string culture, IRepository<Companion> companionsRepository)
    {
        return companionsRepository.SearchByCultureAsync(culture).ToArray() is IEnumerable<Companion> result
            ? Results.Ok(result)
            : Results.NotFound(Array.Empty<Companion>());
    }

    private async Task<IResult> Post(Companion companion, IRepository<Companion> companionsRepository)
    {
        await companionsRepository.InsertAsync(companion);
        await companionsRepository.SaveAsync();
        return Results.Created($"/Companions/{companion.Name}", companion);
    }

    private async Task<IResult> Put(Companion companion, IRepository<Companion> companionsRepository)
    {
        await companionsRepository.UpdateAsync(companion);
        await companionsRepository.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(string name, IRepository<Companion> companionsRepository)
    {
        await companionsRepository.DeleteAsync(name);
        await companionsRepository.SaveAsync();
        return Results.NoContent();
    }
}