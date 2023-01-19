using BannerlordUnits.WebAPI.DataAccess.Repositories;

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
    services.AddDbContext<MyDbContext>(options =>
    {
        var connectionString = ConnectionStringBuilder.BuildFrom(
            builder.Configuration.GetConnectionString("ElephantSQL"));
        options.UseNpgsql(connectionString);
    });
    services.AddScoped<IRepository<Troop>, TroopsRepository>();
    services.AddScoped<IRepository<CustomTroop>, CustomTroopsRepository>();
    services.AddScoped<IRepository<Companion>, CompanionsRepository>();
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = "https://localhost:5002";
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });
    services.AddAuthorization(options =>
    {
        options.AddPolicy("ApiScope", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "TroopsApi");
        });
    });
    services.AddTransient<IApi, TroopsApi>();
    services.AddTransient<IApi, CustomTroopsApi>();
    services.AddTransient<IApi, CompanionsApi>();

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        options.AddPolicy("AllowBlazorOrigin",
            builder =>
            {
                builder.WithOrigins("https://localhost:7297", "http://localhost:5294")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
    });
}

void Configure(WebApplication app)
{
    app.UseAuthentication();
    app.UseAuthorization();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowAllOrigins");
    app.UseHttpsRedirection();
}