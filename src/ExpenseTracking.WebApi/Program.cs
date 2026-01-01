using ExpenseTracking.Application.Extensions;
using ExpenseTracking.Persistence.Extensions;
using ExpenseTracking.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

if (configuration.GetConnectionString("DefaultConnection") is null)
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

string connectionString = configuration.GetConnectionString("DefaultConnection")!;
builder.Services
    .AddPersistence(connectionString)
    .AddApplicationServices();

var app = builder.Build();

app.MapHomeEndpoints();

app.Run();
