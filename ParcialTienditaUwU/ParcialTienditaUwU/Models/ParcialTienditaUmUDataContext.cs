using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParcialTienditaUwU.Models;

public partial class ParcialTienditaUmUDataContext : DbContext
{
    public ParcialTienditaUmUDataContext()
    {
    }

    public ParcialTienditaUmUDataContext(DbContextOptions<ParcialTienditaUmUDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ParcialTienditaUmU.Data;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.OrderDate).HasColumnName("orderDate");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.HasIndex(e => e.OrdersorderId, "IX_Products_OrdersorderId");

            entity.HasIndex(e => e.SellssellId, "IX_Products_SellssellId");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.ProductName).HasColumnName("productName");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Ordersorder).WithMany(p => p.Products).HasForeignKey(d => d.OrdersorderId);

            entity.HasOne(d => d.Sellssell).WithMany(p => p.Products).HasForeignKey(d => d.SellssellId);
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.Property(e => e.SellId).HasColumnName("sellId");
            entity.Property(e => e.SellDate).HasColumnName("sellDate");
            entity.Property(e => e.TotalToPay).HasColumnName("totalToPay");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.FullName).HasColumnName("fullName");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Rol).HasColumnName("rol");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
