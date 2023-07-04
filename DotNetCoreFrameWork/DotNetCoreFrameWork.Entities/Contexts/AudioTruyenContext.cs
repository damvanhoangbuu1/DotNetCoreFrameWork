using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreFrameWork.Entities.Contexts
{
    public partial class AudioTruyenContext : DbContext
    {
        public AudioTruyenContext()
        {
        }

        public AudioTruyenContext(DbContextOptions<AudioTruyenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookCategory> BookCategories { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<TmpStf> TmpStfs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConections"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("audiotr4__lqb");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .HasColumnName("author");

                entity.Property(e => e.Booknm)
                    .HasMaxLength(50)
                    .HasColumnName("booknm");

                entity.Property(e => e.Folderid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("folderid");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .HasColumnName("source");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_category");

                entity.Property(e => e.Bookid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bookid");

                entity.Property(e => e.Catid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("catid");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("chapter");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Bookid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bookid");

                entity.Property(e => e.Fileid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("fileid");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Seq)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("seq");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Url)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<TmpStf>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_stf");

                entity.Property(e => e.Booknm)
                    .HasMaxLength(50)
                    .HasColumnName("booknm");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
