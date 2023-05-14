using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoVariant7.Model;

public partial class DemoVariant7Context : DbContext
{
    public DemoVariant7Context()
    {
    }

    public DemoVariant7Context(DbContextOptions<DemoVariant7Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manafacture> Manafactures { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderproduct> Orderproducts { get; set; }

    public virtual DbSet<Pickuppoint> Pickuppoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=(Ram2003)123;database=demo_variant7", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.CategoryName).HasMaxLength(45);
        });

        modelBuilder.Entity<Manafacture>(entity =>
        {
            entity.HasKey(e => e.IdManafacture).HasName("PRIMARY");

            entity.ToTable("manafacture");

            entity.Property(e => e.IdManafacture).HasColumnName("idManafacture");
            entity.Property(e => e.ManafactureName).HasMaxLength(45);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.OrderPickupPoint, "pick_idx");

            entity.HasIndex(e => e.Fio, "user_idx");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderStatus).HasColumnType("text");

            entity.HasOne(d => d.FioNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Fio)
                .HasConstraintName("user");

            entity.HasOne(d => d.OrderPickupPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderPickupPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pick");
        });

        modelBuilder.Entity<Orderproduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orderproduct");

            entity.HasIndex(e => e.OrderId, "order_idx");

            entity.HasIndex(e => e.ProductArticleNumber, "prod_idx");

            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany()
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prod");
        });

        modelBuilder.Entity<Pickuppoint>(entity =>
        {
            entity.HasKey(e => e.IdPickupPoint).HasName("PRIMARY");

            entity.ToTable("pickuppoint");

            entity.Property(e => e.IdPickupPoint).HasColumnName("idPickupPoint");
            entity.Property(e => e.City).HasMaxLength(45);
            entity.Property(e => e.Street).HasMaxLength(45);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductArticleNumber).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.ProductCategory, "cat_idx");

            entity.HasIndex(e => e.ProductManufacturer, "man_idx");

            entity.HasIndex(e => e.ProductSupplier, "sup_idx");

            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ProductCost).HasPrecision(19, 2);
            entity.Property(e => e.ProductDescription).HasColumnType("text");
            entity.Property(e => e.ProductName).HasColumnType("text");
            entity.Property(e => e.ProductPhoto).HasMaxLength(45);
            entity.Property(e => e.ProductStatus).HasColumnType("text");
            entity.Property(e => e.ProductUint).HasMaxLength(45);

            entity.HasOne(d => d.ProductCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cat");

            entity.HasOne(d => d.ProductManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("man");

            entity.HasOne(d => d.ProductSupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductSupplier)
                .HasConstraintName("sup");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PRIMARY");

            entity.ToTable("supplier");

            entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");
            entity.Property(e => e.SupplierName).HasMaxLength(45);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.UserRole, "user_ibfk_1");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserLogin).HasColumnType("text");
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPassword).HasColumnType("text");
            entity.Property(e => e.UserPatronymic).HasMaxLength(100);
            entity.Property(e => e.UserSurname).HasMaxLength(100);

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .HasConstraintName("user_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
