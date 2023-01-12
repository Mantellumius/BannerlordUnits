using BannerlordUnits.Models;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);
var app = builder.Build();
Configure(app);
foreach (var api in app.Services.GetServices<IApi>()) api.Register(app);
app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<TroopsContext>(options =>
    {
        var connectionString = ConnectionStringBuilder.BuildFrom(
            builder.Configuration.GetConnectionString("ElephantSQL"));
        options.UseNpgsql(connectionString);
    });
    services.AddScoped<ITroopsRepository<Troop>, TroopsRepository>();
    services.AddTransient<IApi, TroopsApi>();
    services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowBlazorOrigin",
            builder =>
            {
                builder.WithOrigins("https://localhost:7297", "http://localhost:5294");
            });
    });
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowBlazorOrigin");
    app.UseHttpsRedirection();
}