using Microsoft.EntityFrameworkCore;
using Npgsql;
using APIProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? Environment.GetEnvironmentVariable("DATABASE_URL");

if (!string.IsNullOrEmpty(connectionString))
{
    // Parse connection string if it's in PostgreSQL URI format
    if (connectionString.StartsWith("postgresql://") || connectionString.StartsWith("postgres://"))
    {
        var uri = new Uri(connectionString);
        var userInfo = uri.UserInfo.Split(':');
        var host = uri.Host;
        var port = uri.Port == -1 ? 5432 : uri.Port;
        var database = uri.AbsolutePath.TrimStart('/');
        var username = Uri.UnescapeDataString(userInfo[0]);
        var password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : "";

        connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true";
    }

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// DbContext
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; }
}

