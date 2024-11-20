using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SalesTaxesApi.Models;

namespace SalesTaxesApi.DbContexts;
public class SalesTaxesDBContext : IdentityDbContext<MyUser>
{
    public SalesTaxesDBContext(DbContextOptions<SalesTaxesDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<MyUser> User { get; set; }
}
