using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SunLight.Database.Server;
using SunLight.Dtos;
using SunLight.Middlewares;
using SunLight.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddYamlFile("config.yml", optional: false);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
    .AddControllers(opts => opts.ModelBinderProviders.Insert(0, new FormDataBinderProvider()))
    .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower);

var selectedDatabase = builder.Configuration["Server:Database"] ?? throw new Exception("Database not provided");
var connectionString = builder.Configuration.GetConnectionString(selectedDatabase);
builder.Services.AddDbContext<ServerDbContext>(opts => opts.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

builder.Services.AddRouting();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UsePerformanceMeter();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.Use(next => context =>
{
    context.Request.EnableBuffering();
    return next(context);
});

app.UseCustomResponseHeaders();

app.MapControllers();
app.Run();