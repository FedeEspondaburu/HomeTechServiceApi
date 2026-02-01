using Application.Services;
using Application.Interfaces;
using Data.Interfaces;
using Data.Repositories;
using Shared.Interfaces;
using Shared.Services;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


#region Database Configuration

var secretPath = Path.Combine(
    builder.Environment.ContentRootPath,
    "Secrets",
    "DbServer.txt"
);

if (!File.Exists(secretPath))
{
    throw new InvalidOperationException($"Secret file not found: {secretPath}");
}

string serverName = File.ReadAllText(secretPath).Trim();

if (string.IsNullOrWhiteSpace(serverName))
{
    throw new InvalidOperationException("DB server secret is empty");
}

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!
    .Replace("{DB_SERVER}", serverName);


builder.Services.AddDbContext<Data.HomeTechServiceDBContext>(options =>
    options.UseSqlServer(
        connectionString,
        b => b.MigrationsAssembly("Data")
    )
);


#endregion

#region Dependency Injection
//Services DI
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICryptographyService, CryptographyService>();
builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();

//Data Repositories DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
