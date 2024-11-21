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

        builder.Entity<TaxType>()
            .HasData(
                new TaxType
                {
                    taxTypeId = 1,
                    taxName = "Basic Tax",
                    rate = 10,
                    created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    isDeleted = false,
                    deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
                },
                new TaxType
                {
                    taxTypeId = 2,
                    taxName = "Import Duty",
                    rate = 5,
                    created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    isDeleted = false,
                    deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
                }
            );

        builder.Entity<ProductType>()
            .HasData(
                new ProductType
                {
                    productTypeId = 1,
                    productTypeName = "Books",
                    isExempt = true,
                    created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    isDeleted = false,
                    deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
                },
                new ProductType
                {
                    productTypeId = 2,
                    productTypeName = "Food",
                    isExempt = true,
                    created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    isDeleted = false,
                    deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
                },
                new ProductType
                {
                    productTypeId = 3,
                    productTypeName = "Medical Products",
                    isExempt = true,
                    created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    isDeleted = false,
                    deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
                },
                new ProductType
                {
                    productTypeId = 4,
                    productTypeName = "Other",
                    isExempt = false,
                    created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                    isDeleted = false,
                    deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
                }
            );
    }

    public DbSet<MyUser> User { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptItem> ReceiptItems { get; set; }
    public DbSet<TaxType> TaxTypes { get; set; }
}
