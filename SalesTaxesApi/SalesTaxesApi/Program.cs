using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesTaxesApi.Configurations;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ConnStr")
    ?? throw new InvalidOperationException("Connection string 'ConnStr' not found.");
builder.Services.ResolveDependencies();

// Remove explicit AddAuthentication for Identity.Application
builder.Services.AddAuthorizationBuilder();

builder.Services.AddControllers();

const string DefaultCorsPolicy = "DefaultCorsPolicy";

builder.Services.AddDbContext<SalesTaxesDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Set up in memory database
//builder.Services.AddDbContext<SalesTaxesDBContext>(
//    options => options.UseInMemoryDatabase("AppDb"));

// Add/setup Identity
builder.Services.AddIdentity<MyUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddRoles<IdentityRole>()
.AddRoleManager<RoleManager<IdentityRole>>()
.AddEntityFrameworkStores<SalesTaxesDBContext>()
.AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    try
    {
        var dbContext = service.GetRequiredService<SalesTaxesDBContext>();
        await dbContext.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = service.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while applying migrations.");
    }
}

app.UseHttpsRedirection();

app.UseCors(DefaultCorsPolicy);

// Ensure UseAuthentication is included for Identity to work
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Default Web API endpoint");

app.MapControllers();

app.Run();
