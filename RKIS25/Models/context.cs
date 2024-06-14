using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace context.Models;

public partial class Conetxt : DbContext
{
    public Conetxt()
    {
    }

    public Conetxt(DbContextOptions<Conetxt> options) : base(options)
    {

    }
    public virtual DbSet<Rolesfor25> Roles { get; set;}

    public virtual DbSet<usersfor25> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=JeyKe65");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rolesfor25>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("rolesfor25");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e =>e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

        });

        modelBuilder.Entity<usersfor25>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("usersfor25");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
            .HasColumnType("character varying")
            .HasColumnName("login");
            entity.Property(e => e.Password)
            .HasColumnType("character varying")
            .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
            .HasMaxLength(11)
            .HasColumnName("phone_number");
            entity.Property(e => e.Birthdate)
            .HasColumnName("birthdate");
            entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
            entity.Property(e => e.Surname)
            .HasMaxLength(50)
            .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Usersfor25s)
            .HasForeignKey(d => d.IdRole)
            .HasConstraintName("users_id_role_fkey");

        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}