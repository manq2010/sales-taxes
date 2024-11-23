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

        builder.Entity<Product>()
        .HasData(
            new Product
            {
                productId = 1,
                productName = "Book",
                unitPrice = 12.49m,
                isImport = false,
                isExempt = true,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 2,
                productName = "Music CD",
                unitPrice = 14.99m,
                isImport = false,
                isExempt = false,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 3,
                productName = "Chocolate bar",
                unitPrice = 0.85m,
                isImport = false,
                isExempt = true,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 4,
                productName = " Imported box of chocolates",
                unitPrice = 10.00m,
                isImport = true,
                isExempt = true,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 5,
                productName = "Imported bottle of perfume",
                unitPrice = 47.50m,
                isImport = true,
                isExempt = false,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 6,
                productName = "Imported bottle of perfume",
                unitPrice = 27.99m,
                isImport = true,
                isExempt = false,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 7,
                productName = "Bottle of perfume",
                unitPrice = 18.99m,
                isImport = false,
                isExempt = false,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 8,
                productName = "Packet of headache pills",
                unitPrice = 9.75m,
                isImport = false,
                isExempt = true,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Product
            {
                productId = 9,
                productName = "Imported box of chocolates",
                unitPrice = 11.25m,
                isImport = true,
                isExempt = true,
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            }
        );

        builder.Entity<Receipt>()
        .HasData(
            new Receipt
            {
                receiptId = 1,
                clientName = "Willing Trader",
                clientEmail = "willing@trader.com",
                created_at = new DateTime(2024, 11, 20, 12, 0, 0),
                updated_at = new DateTime(2024, 11, 20, 12, 0, 0),
                isDeleted = false,
                deleted_at = new DateTime(2024, 11, 20, 12, 0, 0)
            },
            new Receipt
            {
                receiptId = 2,
                clientName = "Test Driving",
                clientEmail = "test@driving.com",
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
