using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<TasksProject> TasksProjects { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddNewtonsoftJsonFile("appconfig.json").Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Sapphir"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.Comments)
                    .IsUnicode(false)
                    .HasColumnName("Comment");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.ShortTaskName).HasColumnName("ShortTaskName");
                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

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
                entity.Property(e => e.ShortName)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TasksProject>(entity =>
            {
                entity
                    //.HasNoKey()
                    .ToTable("TasksProject");

                entity.Property(e => e.AssignedUser).IsUnicode(false);
                entity.Property(e => e.Category).IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.IdProjects).HasColumnName("ID_Projects");
                entity.Property(e => e.ModDate).HasColumnType("datetime");
                entity.Property(e => e.Name).IsUnicode(false);
                entity.Property(e => e.ShortNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Tag).IsUnicode(false);
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