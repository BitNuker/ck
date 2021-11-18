using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CK.EF
{
    public partial class CKContext : DbContext
    {
        public CKContext()
        {

        }

        public CKContext(DbContextOptions<CKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<Trade> Trades { get; set; } 
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=CKBD");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.ToTable("Portfolio");

                entity.Property(e => e.PortfolioId)
                    .ValueGeneratedNever()
                    .HasColumnName("PortfolioID");

                entity.HasOne(e => e.User)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Portfolio_User");

                entity.Property(e => e.Balance).HasColumnType("money");
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.ToTable("Trade");

                entity.Property(e => e.TradeId)
                    .ValueGeneratedNever()
                    .HasColumnName("TradeID");

                entity.Property(e => e.Action).HasMaxLength(10);

                entity.Property(e => e.Asset).HasMaxLength(10);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Currency).HasMaxLength(10);

                entity.Property(e => e.Date).HasMaxLength(10);

                entity.Property(e => e.MarketValue).HasColumnType("money");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.NumberOfShares).HasColumnType("decimal(14, 5)");

                entity.Property(e => e.PortfolioId).HasColumnName("PortfolioID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.Trades)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortfolioTrade");


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RefreshToken).HasMaxLength(100);

                entity.Property(e => e.RefreshTokenExpiration).HasColumnType("datetime");

                entity.Property(e => e.Salt).HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(100);

                entity.Property(e => e.TokenExpiration).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
