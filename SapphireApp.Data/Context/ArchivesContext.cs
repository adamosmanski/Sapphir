using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SapphirApp.Data.Models;

namespace SapphirApp.Data.Context;

public partial class ArchivesContext : DbContext
{
    public ArchivesContext()
    {
    }

    public ArchivesContext(DbContextOptions<ArchivesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CommentsArch> CommentsArches { get; set; }

    public virtual DbSet<ProjectsArch> ProjectsArches { get; set; }

    public virtual DbSet<TasksProjectArch> TasksProjectArches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder().AddNewtonsoftJsonFile("appconfig.json").Build();
        
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Archives"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommentsArch>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("CommentsArch");

            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ShortTaskName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProjectsArch>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("ProjectsArch");

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

        modelBuilder.Entity<TasksProjectArch>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("TasksProjectArch");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
