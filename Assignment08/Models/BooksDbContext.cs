using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment08.Models
{
    public partial class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
        }

        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:assignment08books.database.windows.net,1433;Initial Catalog=BooksDb;Persist Security Info=False;User ID=onkar;Password=ManishPavan@333;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Books__C6D111C9A552617B");

                entity.Property(e => e.Bid).ValueGeneratedNever();

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.AidNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK__Books__Aid__6477ECF3");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__Books__Cid__66603565");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__Books__Pid__656C112C");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Category__C1FFD861C707979E");

                entity.ToTable("Category");

                entity.Property(e => e.Cid).ValueGeneratedNever();

                entity.Property(e => e.Cat).HasMaxLength(50);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Publishe__C5705938C2CD46D1");

                entity.ToTable("Publisher");

                entity.Property(e => e.Pid).ValueGeneratedNever();

                entity.Property(e => e.Paddress).HasMaxLength(50);

                entity.Property(e => e.Pname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
