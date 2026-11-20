using Api.Data;
using Api.Tenancy;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// In-memory SQLite: the shared connection keeps the database alive for the app's lifetime.
var connection = new SqliteConnection("Data Source=:memory:");
connection.Open();
builder.Services.AddSingleton(connection);
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(connection));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentTenant, HeaderCurrentTenant>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    SeedData.Apply(db);
}

app.MapGet("/health", () => Results.Ok());
app.MapControllers();

app.Run();

public partial class Program;
