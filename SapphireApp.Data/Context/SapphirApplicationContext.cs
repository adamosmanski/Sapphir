using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SapphirApp.Data.Context;
using SapphirApp.Data.Models;

namespace SapphirApp.Data.Context
{
    public partial class SapphirApplicationContext : DbContext
    {
        public SapphirApplicationContext()
        {
        }

        public SapphirApplicationContext(DbContextOptions<SapphirApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SapphirApplication;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.ModDate).HasColumnType("datetime");
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
                entity.Property(e => e.LevelAccess).IsUnicode(false);
                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ModDate).HasColumnType("datetime");
                entity.Property(e => e.Password).IsUnicode(false);
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.SecondName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
