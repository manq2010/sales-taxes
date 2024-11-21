using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SalesTaxesApi.Models;
using System.Reflection.Emit;

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
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptItem> ReceiptItems { get; set; }
    public DbSet<TaxType> TaxTypes { get; set; }
}
