using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.colorId).HasName("PK__Color__colorId__ADC332CFB675253E");

                entity.Property(e => e.colorId).ValueGeneratedOnAdd();
                entity.Property(e => e.ColorName)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.IsInStock)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.presentationOrder)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
