using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class ColorsContext : DbContext
{
    public ColorsContext(DbContextOptions<ColorsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.colorId).HasName("PK__tmp_ms_x__92B908E98C9E259A");

            entity.Property(e => e.colorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("colorId");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("colorName");
            entity.Property(e => e.IsInStock).HasColumnName("isInStock");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.presentationOrder).HasColumnName("presentationOrder");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
